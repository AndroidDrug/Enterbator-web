using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntrebatorEnumandConstants
{
    public static class UIEnums
    {

        public enum UploadedFileErrorType
        {
            Extension,
            FileSize
        }

        public enum RegistrationStatus
        {
            Registered = 1,
            Approved = 2

        }
        public enum FeedType
        {
            Text = 1,
            Photo = 2,
            Video = 3,
        }
        public enum InvitaionStatus
        {
            Sent = 1,
            Accept = 2,
            Decline = 3,
            Delete = 4
        }
        public enum MInvitationStatus
        {
            Sent = 1,
            Registered = 2
        }
        public enum QuizQuestionStatus
        {
            Asked = 1,
            Replied = 2
        }
        /// <summary>
        /// For Delete message from inbox
        /// </summary>
        public enum MessageStatus
        {
            Send = 1,
            SentDelete = 2,
            InboxDelete = 3,
            Read = 4,
            UnRead = 5
        }

        public enum ReportBusinessStatus
        {
            InsertTicket = 1,
            ActiveTicket = 2,
            ClosedTicket = 3
        }

        public enum PointsType
        {
            Credit = 1,
            Debit = 2
        }

        public enum ReferralType
        {
            Public = 1,
            Connections = 2,
            Specific = 3,
        }

        public enum RegisteredThrough
        {
            WebSite = 1,
            App = 2
        }
        public enum InvQuiz
        { 
        Invited=1,
            Participated=2
        }
        public enum FeedAction
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }
        public enum PushNotificationforMobile
        { 
            WallPosting = 1,
            ReqPosting = 2,
            ServiceProducts = 3,
            Quiz = 4,
            NotUpdatedDetailsCompltly= 5,
            ProfilePicNotUploaded = 6,
            AccountBlocked = 7,
            AccountDeleted = 8,
            AccountActive= 9,
            AccountRejected = 10,
            LogoNotUpdated = 11,
            ConnectwithMembers =12,
            FromHelpdeskToInviteTwoMember=13,
            FeedorPostBlockedbyStateAdmin = 14,
            BothLogoNPhotonotUploaded = 15,
            QuickLinksCreatedByStateAdmin =16
           
        
        }
    }
}
