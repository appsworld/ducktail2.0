## Ducksgiving: Ducktail's Renewed Efforts to Compromise Users and Enterprises


### 🚨 Overview
Ducktail, a notorious cyber threat actor known for hijacking Facebook Business and Ads accounts, has recently undergone a significant transformation, emerging with enhanced capabilities and a growing victim count. Their revised tactics have proven highly effective, expanding their reach to thousands of users. Their victims include multiple admins of accounts with millions of Facebook Ad-spend over a fiscal year.


Ducktail's newfound success stems partly from their ability to craft viral content on LinkedIn, effectively targeting specific market segments. This approach has enabled them to infiltrate a broader range of victims, increasing their overall impact. Moreover, their enhanced source code, now decrypted for thorough analysis, reveals advanced techniques and evolving tactics, making them more difficult to detect and neutralize.


By fostering collaboration and adopting a comprehensive approach to cybersecurity, organizations can better defend against sophisticated attacks and safeguard the integrity of their platforms.




### 📋 Team Structure and Operations


We have tracked the Ducktail cyber threat actor for the past 3 years. In the past few months the threat actor has grown its headcount and structure. They operate with a well-defined team structure that facilitates the development, implementation, and operation of their malicious tools and techniques.


**Architects:** The architects are the masterminds behind the strategic development and core framework of the malware. They are responsible for designing the overall architecture, outlining the functionalities, and ensuring the smooth integration of all components.


**Developers:** The developers are the craftsmen who bring the architects' vision to life. They are tasked with refining and implementing the code, ensuring effectiveness and evasiveness. They meticulously craft the code to achieve the desired malicious objectives while also incorporating obfuscation techniques to impede detection.


**Operators:** The operators are the hands-on individuals who utilize the tools to infiltrate and manipulate Facebook Ads accounts. They wield the malware to gain unauthorized access, control compromised accounts, and execute malicious activities.


## Attack Chain Diagram


![Ducktail Attack Chain](https://raw.githubusercontent.com/appsworld/ducktail2.0/main/attack_diagram_vert.png)


This diagram illustrates the various stages of the Ducktail attack chain, showcasing a summarized view of the methods and processes used by the threat actor.


### 🕵️ Methodology


Ducktail employs a sophisticated methodology to target and compromise Facebook Ads accounts, utilizing a range of techniques to achieve its objectives.


**Data Harvesting:** The [`CKResolver`](https://github.com/appsworld/ducktail2.0/blob/main/SourceCode-Decrypted/iCollector.Job.Handler/CKResolver.cs#L14) class in the source code is a powerful tool designed to locate and decrypt sensitive data across various browsers. This malicious module targets valuable information such as *credit card details*, *browsing history*, and *passwords*, significantly increasing the potential impact of the attack.


**Session Exploitation:** Ducktail continues to exploit authenticated sessions to gain unauthorized access to Facebook Ads accounts. This technique involves intercepting or stealing valid session cookies or tokens, allowing the attackers to bypass MFA and seamlessly infiltrate the targeted accounts. Most of the activities can be observed within the [`TokenJob`](https://github.com/appsworld/ducktail2.0/blob/main/SourceCode-Decrypted/iCollector.Job.SocialJob/GetTokenJob.cs#L8)


**Client Information Enrichment:** The stolen data is further enriched with additional client information gleaned from various sources. This additional context enhances the value and exploitability of the compromised data, enabling the attackers to tailor their malicious activities more effectively.


### 🛑 Indicators of Compromise (IoCs)


To help identify and mitigate potential threats, here are some Indicators of Compromise (IoCs) associated with Ducktail's activities:


| IOC Type | IOC Value |
|---|---|
| SHA256 | 0253749e47411907b3c32cd7c12bf9d5e4b5d8ca8b972435c0669de300473545 |
| SHA256 | fc9971a148e55f4053554d67a84296848dd63c895d796426116a2dce9fc7d818 |
| User-Agent | Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 |
| User-Agent | Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0 |
| User-Agent | Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{0} Safari/537.36 |
| Mutex | APPXALO |
| Persistence (Registry) | Software\\Microsoft\\Windows\\CurrentVersion\\Run |
| URL | https[://]note[.]2fa[.]live/note/ |
| URL | https[://]api[.]telegram[.]org/bot |
| SQL Query | SELECT name_on_card, expiration_month, expiration_year, card_number_encrypted FROM credit_cards |
| SQL Query | SELECT url FROM visits order by visit_time desc |
| SQL Query | SELECT action_url, username_value, password_value FROM logins order by date_password_modified desc |
| URL | https[://]www[.]whatismybrowser[.]com/detect/what-is-my-user-agent |
| URL | https[://]www[.]whatismybrowser[.]com/detect/what-is-my-ip-address|


### 💥 Impact: Victim's Account Compromise


The successful compromise of Facebook Ads accounts by Ducktail can have significant consequences for both individuals and organizations.


**Account Takeover:** Attackers can impersonate legitimate users by adding themselves as admins, gaining complete control over the targeted accounts. This enables them to manipulate ad campaigns, misuse ad budgets, and potentially compromise the security of connected websites.


**Malicious Ads:** The attackers also offer a service that allows them to create malicious ads on behalf of others using the compromised accounts.


**Post-Compromise Data Harvesting:** Beyond account compromise, Ducktail's activities extend to placing tracking pixels on websites managed by victim organizations. This quasi supply chain attack method enables broader data harvesting, highlighting the need for comprehensive security strategies beyond immediate account protection.


**The MFA Dilemma and Local Data Storage Concerns:** The Ducktail's ability to bypass multi-factor authentication (MFA) signals an urgent need to rethink the storage of sensitive user and authentication data locally on machines. This vulnerability exposes the limitations of traditional MFA methods against advanced malware that manipulates local data.




### 🛡️ Recommendations


To safeguard your Facebook Ads accounts from Ducktail's malicious activities, consider implementing these robust security measures:


1. Implement Stringent Monitoring: Continuously monitor Facebook Ads account activities for any unusual or unauthorized actions. This proactive approach can help identify potential compromises early on, allowing for prompt remediation.


2. Regularly Review User Access: Periodically review user access permissions and privileges to ensure they align with current roles and responsibilities. This practice helps prevent unauthorized access and minimizes the impact of compromised accounts.


3. Educate Staff: Train employees not to log into work accounts from personal devices. This includes identifying suspicious login attempts, unauthorized account activity, and unusual ad campaigns.


4. Minimize Privileges for Consultants: For those who use consultancies, which are most of the victims we observed, you should minimize the privileges assigned to them on ad accounts. This helps limit the potential damage if their accounts are compromised.


5. Restrict Contractor and Agency Access: Do not allow contractors and agencies to log on to your corporate network from personal devices. This prevents them from accessing sensitive data and reduces the risk of malware infections.


### 📊 MITRE ATT&CK Techniques


| Technique | Description |
|---|---|
| T1070 | Initial Access |
| T1020 | Collection |
| T1059 | Command and Control |
| T1021 | Data Exfiltration |


### 📝 Conclusion


Ducktail's evolved capabilities and organized team structure represent a significant threat to Facebook Ads accounts. Understanding their methods and implementing robust security measures is crucial for mitigating these sophisticated attacks.
