﻿using ProjectTracker.Models.Project.ViewModels;

namespace ProjectTracker.Models.Project.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }

        public int Stage { get; set; }

        public string Comments { get; set; }

        public ModifyProjectViewModel ToModifyProjectViewModel()
        {
            return new ModifyProjectViewModel()
            {
                Id = Id,
                Name = Name,
                Status = Status,
                Stage = Stage,
                Comments = Comments
            };
        }

        public ProjectViewModel ToProjectViewModel()
        {
            return new ProjectViewModel()
            {
                Id = Id,
                Name = Name,
                Status = Status,
                Stage = Stage,
                Comments = Comments
            };
        }

    }
}
