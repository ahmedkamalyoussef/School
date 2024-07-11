﻿using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Response;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Queries.Hnadlers
{
    public class StudentHandler(IStudentService studentService ,IMapper mapper) : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
    {
        #region fields
        private readonly IStudentService _studentService = studentService;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region handlers
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync();
            var response = _mapper.Map<List<GetStudentListResponse>>(students);
            return Success(response);
        }
        #endregion
    }
}
