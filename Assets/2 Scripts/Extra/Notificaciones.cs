using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notificaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Borramos las notificaciones que ya han sido mostradas 
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        /////////Creamos un canal de notificaciones/////////
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        /////////Ejemplo de notificacion simple/////////
        var notification = new AndroidNotification();
        notification.Title = "No pierdas tu racha";
        notification.Text = "Llevas ya un tiempo sin jugar";

        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";


        //Se activará una notificacion cada x tiempo
        notification.FireTime = System.DateTime.Now.AddSeconds(480);

        //Finalmente enviamos la notificacion al móvil
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        //emos recojido la notificacion en una variable llamada id para comprobar si el mensaje esta mostrado para no acumular mensajes
        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id)== NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
