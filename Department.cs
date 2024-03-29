﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCRDesktopApp
{
    internal class Department
    {
        [JsonPropertyName("departmentId")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("managerId")]
        public int ManagerId { get; set; }
    }
}
