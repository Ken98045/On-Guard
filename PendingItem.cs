using System;

namespace SAAI
{
/// <summary>
/// A class to store information for recently changed/motion files.
/// It tracks that information through the whole process of sending the information
/// to the AI
/// </summary>
  public class PendingItem
  {
    public Guid AOIid { get; }
    public string CameraPath { get; }
    public string PendingFile { get; set; }     // The file we want the AI to look at
    public DateTime TimeEnqueued { get; set; }  // The time we put it in the queue waiting for the AI
    public DateTime TimeDispatched { get; set; }  // The time the queue dispatched it to the AI
    public DateTime TimeCompleted { get; set; }  // The time the AI completed the project and returned the item list
    public CameraData CamData { get; set; }


    public PendingItem(CameraData camData, string fileName)
    {
      CamData = camData;
      PendingFile = fileName;
      TimeEnqueued = DateTime.Now;    // we only create one when we are ready to put it in the queue
      TimeCompleted = TimeEnqueued;
      TimeDispatched = TimeEnqueued;
    }

    public TimeSpan TimeInQueue()
    {
      return DateTime.Now - TimeEnqueued;
    }

    // Only call this when we are are ready to dispatch
    public TimeSpan TimeToDispatch()
    {
      TimeDispatched = DateTime.Now;
      return TimeDispatched - TimeEnqueued;
    }

    public TimeSpan TimeProcessingByAI()
    {
      TimeCompleted = DateTime.Now;
      return TimeCompleted - TimeDispatched;
    }

    public TimeSpan TotalProcessingTime()
    {
      return TimeCompleted - TimeEnqueued;
    }
  }

}
