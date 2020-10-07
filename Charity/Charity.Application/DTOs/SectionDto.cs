﻿using System.Collections.Generic;

 namespace Charity.Application.Module.DTOs
{
    public class SectionDto<T>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}