using Microsoft.AspNetCore.Identity;
using Nemesys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {



        /*
        * Upvotes
        */
        bool UserUpvoteReportExist(string userId, int reportId); // return TRUE if the user already voted for the reportId and FALSE otherwise
        IEnumerable<Upvote> GetAllUpvotesUser(string userId); // return all the Upvotes for a UserId
        IEnumerable<Upvote> GetAllUpvotesReport(int reportId);  // return all the Upvotes for a ReportId
        void CreateUpvote(Upvote upvote); // create a nex Upvote in the DB
        Task DeleteUpvotes( int reportId); // delete Upvote with the reportId
        Task DeleteUpvotes(IEnumerable<Upvote> upvote); // delete all the upvote from the list


        /*
         * Hall of Fame
         */
        HallOfFameListViewModel GetHallOfFameList(); // return HallOffFameList


        /*
        * REPORTS
        */
        IEnumerable<Report> GetAllReports(); // return all reports
        IEnumerable<Report> GetAllReports(string userId); // return all reports where UserId = userId
        Report GetReportById(int reportId); // return the report with the same id as reportId
        ReportListViewModel GetReportListViewModel(string userId); // return allR eportsViewModel where UserId = userId
        IEnumerable<ReportViewModel> GetAllReportsViewModel(IEnumerable<Report> reports, string userId);      
        ReportViewModel GetReportViewModel(Report report); // changes Report to ReportViewModel

        /*
         * dbo.Reports UPDATES
         */
        void CreateReport(Report report); // add Report in the Db
        void CreateReport(EditReportViewModel reportEditVM); // transform EditReportViewModel to Report and then calls CreateReport(report)
        Task DeleteReport(int reportId); // calls DeleteReport( GetReportById( reportId)) and then calls DeleteInvestigation( reportId) and DeleteUpvote(reportId)
        Task DeleteReport(Report report); // delete reportin the DB 
        void UpdateReport(Report report); // update the reports in the Db





        /*
         * INVESTIGATION
         */
        IEnumerable<Investigation> GetAllInvestigations(); // return all the Investigations
        IEnumerable<Investigation> GetAllInvestigations(string userId);  // return all the Investigatione done by UserId
        InvestigationListViewModel GetInvestigationListViewModel(string userId); // return InvestigationListViewModel for UserID
        IEnumerable<InvestigationViewModel> GetAllInvestigationsViewModel(IEnumerable<Investigation> investigations); // changes List of Investigation to a list of InvestigationViewModel
        InvestigationViewModel GetInvestigationViewModel(Investigation investigation, Report report); // return InvestigationViewModel
        InvestigationViewModel GetInvestigationViewModel(int id); // return   InvestigationeViewModel with id
        InvestigationViewModel GetInvestigationViewModel(Investigation investigation); // transform Investigation into InvestigatioViewModel
        Investigation GetInvestigationById(int investigationId); // return INvestigation with the id 
        Investigation GetInvestigationByReportId(int reportId); // return INvestigation with the reportId
        bool InvestigationForReportIdExist(int reportId); // tell if there is an investigation or not with the reportId
        Investigation EditInvestigationViewModelToInvestigation(EditInvestigationViewModel editInvVM); // transform EditInvestigation in an Investigation 
        void CreateNewInvestigation(EditInvestigationViewModel editInvVM); // create a new investigation




        /*
         * dbo.Investigations UPDATES
         */
        void CreateInvestigation(Investigation investigation);  // create a new investigation
        void UpdateInvestigation(Investigation updatedInvestigation); // Update the investigation
        Task DeleteInvestation(Investigation investigation); // Delete the investigation







        /*
         * STATUS 
         */
        StatusViewModel GetStatusViewModel(Status status); // transform status in statusViewModel
        
        /*
         * dbo.Status access
         */
        IEnumerable<Status> GetAllStatus(); // return all status
        IEnumerable<string> GetAllStatusString(); // return the status in a String list 


        /*
         * TYPE OF HAZARD 
         */
        TypeOfHazardViewModel GetTypeOfHazardViewModel(TypeOfHazard typeOfHazard); // transform TypeOfHazard in TypeOfHazardViewModel 


        /*
         * dbo.TypeOfHazard access
         */
        IEnumerable<TypeOfHazard> GetAllTypesOfHazard(); // return all the TypeOfHazard
        IEnumerable<string> GetAllTypesOfHazardString(); // return all the type of hazard in string 



        /*
         * AuthorViewModel
         */
        AuthorViewModel GetAuthorViewModel(string UserId); // return the Authorview model 

    }
}
