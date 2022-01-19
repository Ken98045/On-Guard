#This application works with almost any IP/network camera and adds artificial intelligence designed to identify security related pictures. More specifically, it uses DeepStack as an AI to intelligently identify objects in still (.jpg) pictures. It allows the user to monitor as many cameras as desired. It allows the user to visually create multiple areas that are of security interest, including the types of objects that are of interest in each area.

Version 3.0.1 is a significant update to previous versions. The most dramatic difference is that it fully supports any known camera that supports ONVIF or HTTP. On Guard can now obtain and analyze pictures from (1) the camera itself without disk storage (2) messages sent by a camera using FTP, and taking advantage of motion sensing capabilities of the camera (3) Blue Iris or other applications that write motion related still images to disk.

On Guard 3.0 features

    It is provided free of charge.
    ONVIF and HTTP based cameras are fully supported. This should include almost any camera not locked into a manufacturer proprietary system.
    Is fully compatible with, but not reliant on Blue Iris.
    Supports multiple cameras.
    Support for cameras with different resolution and cameras from different manufacturers.
    You can design areas of interest (zones) to identify or ignore activity in an area, including overlapping areas.
    You can design your areas to be in almost any shape desired (a 64x64 grid on the pictures).
    You can choose to base security notifications based on the size of identified objects (how big and how close they are to the camera).
    Supports facial recognition.
    Optionally manage the start/stop/reset of the DeepStack AI.
    Notify any application that can take an action as a result of an HTTP message/request.
    Supports IFTTT activation of lights and other smart devices.
    Supports MQTT.
    Supports email notification of clients with attached pictures. This also includes the ability to send MMS/SMS messages to phones that support it.
    Supports Pan/Tilt/Zoom, and move to preset for cameras that support these features.
    Tracks pictures with identified items of interest in a database so that you can move only through those pictures if desired.
    Provides a timeline scroll bar. You can now use a track bar to scroll to pictures at any desired date/time.
    Cleanup old/uninteresting pictures for one or all cameras.
    Detailed documentation/instructions are included.
    Can display snapshot pictures/video as an aid in defining areas of interest and camera positioning.

Features Not Supported

    Does NOT store video to disk.
    Does NOT playback videos.
    While you can play live video (motion .jpg) directly from a camera, this capability is limited (and not smooth).
    Does not support many doorbell cameras, and cameras locked into a proprietary camera ecosystem.

Please refer to the file OnGuard-ReadMe.docx located in the docs folder for setup and use instructions.
Please use only Version 3.0.1 or later!
