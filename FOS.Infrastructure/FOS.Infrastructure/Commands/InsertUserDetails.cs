﻿using FOS.Infrastructure.Services.FileServer;
using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;
using System.Text;

namespace FOS.Infrastructure.Commands
{
    public class InsertUserDetails
    {
        public class Command(InsertUserDetailsModel newUserdetails) : IRequest<int>
        {
            // here give model name
            public InsertUserDetailsModel UserdetailsCommand { get; set; } = newUserdetails;
        }


        public class Handler(IUsermanagementRepository repository, IFileServerService fileServerService) : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationtoken)
            {
                if (!request.UserdetailsCommand.UserImagepath.Contains("http"))
                {
                    var userImagepathServer = fileServerService.UploadFile($"USERS/{request.UserdetailsCommand.UserName.ToUpper()}/{request.UserdetailsCommand.UserImagepath}", request.UserdetailsCommand.UserImageContent!);
                    request.UserdetailsCommand.UserImagepath = userImagepathServer;
                }
                return await repository.InsertUserDetails(request.UserdetailsCommand.CompanyId.GetValueOrDefault(),
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
                    request.UserdetailsCommand.UserGroup,
                    request.UserdetailsCommand.EmailID,
                    request.UserdetailsCommand.Dateofbirth.GetValueOrDefault(),
                    request.UserdetailsCommand.RelivingDate,
                    request.UserdetailsCommand.FatherName,
                    request.UserdetailsCommand.MotherName,
                    request.UserdetailsCommand.SpouseName,
                    request.UserdetailsCommand.MaritialID.GetValueOrDefault(),
                    request.UserdetailsCommand.AadharNumber,
                    request.UserdetailsCommand.PanNumber,
                    request.UserdetailsCommand.Address,
                    request.UserdetailsCommand.UserImagepath,
                    request.UserdetailsCommand.IsActive.GetValueOrDefault(),
                    request.UserdetailsCommand.CreatedBy.GetValueOrDefault(),
                    request.UserdetailsCommand.ErrorCode.GetValueOrDefault());


            }
        }
    }
}
