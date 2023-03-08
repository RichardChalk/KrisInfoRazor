﻿namespace KrisInfoRazor.Models
{
    public class Area
    {
        // Denna klass behövs för att representera en array i json responsen från Krisinformation
        // I responsen heter arrayen 'Area'... klassnamet måste matcha det namnet
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
