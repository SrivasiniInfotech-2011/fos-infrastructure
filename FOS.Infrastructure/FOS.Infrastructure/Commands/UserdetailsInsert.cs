using FOS.Models.Requests;
using FOS.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
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
            public UsercDetailsRequestModel UserdetailsCommand { get; set; }
            public Command(UsercDetailsRequestModel newUserdetails)
            {
                UserdetailsCommand = newUserdetails;
            }
        }


        //public class Handler : IRequestHandler<Command, int>
        //{
        //    private readonly IUsermanagementRepository _usermanagementRepository;
        //    public Handler(IUsermanagementRepository repository)
        //    {
        //        _usermanagementRepository = repository;
        //    }

        //    public Task<int> Handle(Command request, CancellationToken cancellationToken)
        //    {
        //        int errorCode = 0;
        //        return _usermanagementRepository.InsertUserDetails(
        //                                  request.UserdetailsCommand.UserInsertDetails.CompanyId.GetValueOrDefault(), int User_ID, string UserCode, string UserName, int ? genderId,
        //                                   string Password, DateTime ? DOJ, string mobileNumber, string ? EmergencycontactNumber, string Designation,
        //                                   int UserLevelID, int ReportingNextlevel, int User_Group, string EmailID, DateTime ? Dateofbirth, string FatherName, string MotherName
        //                                  , string SpouseName, int Maritial_ID, string Aadhar_Number, string PAN_Number, string Address, string User_Imagepath, int Is_Active,
        //                                   int createdBy, int errorCode);
        //    }
        //}
    }
}
