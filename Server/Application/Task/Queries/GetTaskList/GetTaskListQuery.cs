﻿using MediatR;

namespace Server.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListVm>
    {
        public string ProjectName { get; set; }

        public GetTaskListQuery(string name)
        {
            ProjectName = name;
        }
    }
}
