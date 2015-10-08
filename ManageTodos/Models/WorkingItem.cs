﻿using System;
using PostSharp.Patterns.Model;

namespace TimeManager.ManageTodos.Models
{

    [NotifyPropertyChanged]
    public class WorkingItem
    {
        #region properties
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        #endregion

    }
}
