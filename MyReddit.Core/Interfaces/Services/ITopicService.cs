﻿using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces.Services
{
    public interface ITopicService
    {
        Task<Guid> AddTopic(Topic topic);
        Task<List<Topic>> GetAllTopics();
        Task<List<Topic>> GetTopicByName(string name);
        Task<Guid> UpdateTopic(Guid id, string name);
        Task<Guid> DeleteTopic(Guid id);
    }
}
