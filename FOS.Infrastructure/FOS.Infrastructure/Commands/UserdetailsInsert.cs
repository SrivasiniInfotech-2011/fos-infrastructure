using FOS.Models.Entities;
using FOS.Models.Requests;
using FOS.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityServer4.Models.IdentityResources;

namespace FOS.Infrastructure.Commands
{
    public class UserdetailsInsert
    {
        public class Command : IRequest<int>
        {
            // here give model name
            public UserInsertDetailsModel UserdetailsCommand { get; set; }
            public Command(UserInsertDetailsModel newUserdetails)
            {
                UserdetailsCommand = newUserdetails;
            }
        }


        public class Handler : IRequestHandler<Command, int>
        {

            // here give repository name
            private readonly IUsermanagementRepository _usermanagementrepository;
            public Handler(IUsermanagementRepository repository)
            {
                _usermanagementrepository = repository;
            }

            public Task<int> Handle(Command request, CancellationToken cancellationtoken)
            {
                int errorcode = 0;
                //the Datas from UserInsertDetailsModel
                return _usermanagementrepository.InsertUserDetails(request.UserdetailsCommand.CompanyId.GetValueOrDefault(),
                    request.UserdetailsCommand.UserID.GetValueOrDefault(),
                    request.UserdetailsCommand.UserCode,
                    request.UserdetailsCommand.UserName,
                    request.UserdetailsCommand.GenderId.GetValueOrDefault(),
                    request.UserdetailsCommand.Password,
                    request.UserdetailsCommand.DOJ.GetValueOrDefault(),
                    request.UserdetailsCommand.MobileNumber,
                    request.UserdetailsCommand.EmergencycontactNumber,
                    request.UserdetailsCommand.Designation,
                    request.UserdetailsCommand.UserLevelID.GetValueOrDefault(),
                    request.UserdetailsCommand.ReportingNextlevel.GetValueOrDefault(),
                    request.UserdetailsCommand.UserGroup.GetValueOrDefault(),
                    request.UserdetailsCommand.EmailID,
                    request.UserdetailsCommand.Dateofbirth.GetValueOrDefault(),
                    request.UserdetailsCommand.FatherName,
                    request.UserdetailsCommand.MotherName,
                    request.UserdetailsCommand.SpouseName,
                    request.UserdetailsCommand.MaritialID,
                    request.UserdetailsCommand.AadharNumber,
                    request.UserdetailsCommand.PanNumber,
                    request.UserdetailsCommand.Address,
                    request.UserdetailsCommand.UserImagepath,
                    request.UserdetailsCommand.IsActive.GetValueOrDefault(),
                    request.UserdetailsCommand.CreatedBy.GetValueOrDefault(),
                    request.UserdetailsCommand.ErrorCode.GetValueOrDefault(),
                                         );
            }
        }
    }
}
