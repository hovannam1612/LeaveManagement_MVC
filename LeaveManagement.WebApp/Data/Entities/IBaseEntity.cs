using System;

namespace LeaveManagement.WebApp.Data.Entities
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}