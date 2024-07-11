﻿using School.Data.Entities;

namespace School.Domain.IGenericRepository_IUOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; set; }



        Task<int> SaveChangesAsync();
    }
}
