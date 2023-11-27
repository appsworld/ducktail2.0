using System.Collections.Generic;

namespace iCollector.Job.Model;

internal class JobModel<T>
{
	public bool SuccessWhenAnyStepSuccess;

	public bool SuccessWhenAllStepSuccess;

	public bool ResultAtLastStepSuccess;

	public bool ResultAtAnyLastStepSuccess;

	public string Name { get; set; }

	public List<Step> Steps { get; set; }

	public bool Success { get; set; }

	public T Result { get; set; }
}
