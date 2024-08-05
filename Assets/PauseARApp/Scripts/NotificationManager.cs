using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Notifications.iOS;

public class NotificationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // request permission to use notifications
        StartCoroutine(RequestAuthorization());
    }

    IEnumerator RequestAuthorization()
    {
        using (var req = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound, true))
        {
            yield return req;
            Debug.Log("Authorization request completed: " + req.Granted);
        }
    }

    public void ScheduleNotification(int minutes)
    {
        // create notification content
        iOSNotificationTimeIntervalTrigger timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new System.TimeSpan(0, minutes, 0),
            Repeats = false
        };

        iOSNotification notification = new iOSNotification()
        {
            Identifier = "break_notification",
            Title = "pause.",
            Body = "time to take a break. strech your legs and reset.",
            Subtitle = "health reminder",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "break_category",
            ThreadIdentifier = "break_thread",
            Trigger = timeTrigger,
        };

        // shcedule notification
        iOSNotificationCenter.ScheduleNotification(notification);

        // log notification scheduling
        Debug.Log("Notificationscheduled to trigger in " + minutes + " minutes.");
    }
}
