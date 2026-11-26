using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Domain.Entities
{
    public class Realization
    {
        //Entités
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public string ShortDescription { get; private set; } = "";
        public string Title { get; private set; } = "";
        public string SubTitle { get; private set; } = "";
        public bool IsPublic { get; private set; }
        public string ProjectUrl { get; private set; } = "";
        public string AboutDescription { get; private set; } = "";
        public string ProjectDescription { get; private set; } = "";
        public string GoalDescription { get; private set; } = "";
        public List<string> Qualites { get; private set; } = [];
        //Relatrion
        public Service Service { get; private set; } = null!;
        public ServiceContent ServiceContent { get; private set; } = null!;
        public ICollection<RealizationImage> RealizationImages { get; private set; } = [];
        public Realization() { }
    }
}
