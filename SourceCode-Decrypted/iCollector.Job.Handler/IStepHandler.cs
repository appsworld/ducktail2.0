using iCollector.Job.Model;

namespace iCollector.Job.Handler;

internal interface IStepHandler
{
	void Handle(JobContext jobCtx, Step step);

	StepType GetStepType();
}
