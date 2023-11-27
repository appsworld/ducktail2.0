"""
The module provides utilities for decrypting encoded strings within the decompiled Ducktail C# source code files. 
It includes functionality to decrypt strings using the AES algorithm in CBC mode, read 
structured encrypted strings, process C# source files by decrypting specific encrypted 
strings, and replicate the directory structure for modified files.
"""
import base64
import os
import re
import shutil
from typing import Optional

from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives import padding
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes


def decrypt(input_string: str, key: bytes) -> bytes:
    """
    Decrypts the given input string using AES algorithm in CBC mode.

    Args:
        input_string: The base64 encoded string to be decrypted.
        key: The decryption key in bytes.

    Returns:
        The decrypted data as bytes.
    """
    backend = default_backend()
    input_data = base64.b64decode(input_string)
    iv = input_data[:16]
    cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
    decryptor = cipher.decryptor()
    padded_plaintext = decryptor.update(input_data[16:]) + decryptor.finalize()
    unpadder = padding.PKCS7(128).unpadder()
    return unpadder.update(padded_plaintext) + unpadder.finalize()


def read_struct_encrypted(text: str) -> Optional[str]:
    """
    Decrypts a structured encrypted string.

    Args:
        text: The structured encrypted string to be decrypted.

    Returns:
        The decrypted string or the original text if decryption is not possible.
    """
    if not text:
        return text

    try:
        split_index = text.find(".")
        if split_index == -1:
            return text  # Return the original text if no '.' found

        encrypted_data = text[split_index + 1 :]
        key_b64 = text[:split_index]
        key = base64.b64decode(key_b64 + "==")  # Add padding if needed
        return decrypt(encrypted_data, key).decode()
    except Exception as e:
        print(f"Error decrypting {text}: {e}")
        return text


def inline_decrypt_file(file_path: str) -> str:
    """
    Reads a source code file, decrypts the encoded strings using read_struct_encrypted,
    and replaces them inline.

    Args:
        file_path: The path to the source code file.

    Returns:
        The modified source code with decrypted strings.
    """
    with open(file_path, "r") as file:
        source_code = file.read()

    pattern = r'(\w+)\s*=\s*"([^"]+)"'
    matches = re.findall(pattern, source_code)

    for var_name, encrypted_str in matches:
        decrypted_str = read_struct_encrypted(encrypted_str)
        source_code = source_code.replace(
            f'{var_name} = "{encrypted_str}"', f'{var_name} = "{decrypted_str}"'
        )

    return source_code


def process_directory(
    source_directory_path: str, target_directory_path: Optional[str] = None
):
    """
    Processes all C# files in the given directory, copying them to a target directory.

    Args:
        source_directory_path: The path to the directory containing C# files.
        target_directory_path: The path to the target directory where processed files will be saved.

    """
    if target_directory_path is None:
        target_directory_path = source_directory_path + "_decrypted"

    if not os.path.exists(target_directory_path):
        os.makedirs(target_directory_path)

    for root, dirs, files in os.walk(source_directory_path):
        for dir in dirs:
            os.makedirs(
                os.path.join(
                    target_directory_path,
                    os.path.relpath(os.path.join(root, dir), source_directory_path),
                ),
                exist_ok=True,
            )

        for file in files:
            source_file_path = os.path.join(root, file)
            target_file_path = os.path.join(
                target_directory_path,
                os.path.relpath(source_file_path, source_directory_path),
            )

            if file.endswith(".cs"):
                modified_source_code = inline_decrypt_file(source_file_path)
                with open(target_file_path, "w") as modified_file:
                    modified_file.write(modified_source_code)
                print(f"Processed and saved file: {target_file_path}")
            else:
                shutil.copy2(source_file_path, target_file_path)
