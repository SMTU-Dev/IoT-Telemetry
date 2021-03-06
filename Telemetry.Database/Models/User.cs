﻿using System;
using System.Collections.Generic;
using Telemetry.Database.Base;

namespace Telemetry.Database.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}