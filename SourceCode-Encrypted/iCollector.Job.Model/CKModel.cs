using System.Collections.Generic;

namespace iCollector.Job.Model;

internal class CKModel
{
	public bool Valid { get; set; }

	public string Path { get; set; }

	public string LcsPath { get; set; }

	public byte[] LcsBytes { get; set; }

	public string Type { get; set; }

	public ClientProcess Process { get; set; }

	public ClientInfo ClientInfo { get; set; }

	public List<CKProfile> Profiles { get; set; }
}
