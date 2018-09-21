<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Associative.Master" AutoEventWireup="true" CodeBehind="AddMemberShip.aspx.cs" Inherits="Entrebator.Associative.AddMemberShip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Associatmstr" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    All Users Data
                </div>
                <div class="panel-body">
                    <table id="tblAppmnt" class="table table-bordered table-condensed table-hover table-responsive"></table>
                </div>
            </div>
        </div>
    </div>
     <div class="modal" id="modalsmall" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog" style="padding-top: 180px; padding-left: 270px;">
            <div class="form-group">
                <img src="../Documents/Common/3.GIF" />
            </div>
        </div>
    </div>
    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script type="text/javascript">
        var UserID = '<%= Session["UserID"]%>';
        $(document).ready(function () {
            SP_EB_TOgetUsersForAppointMentPerpose();
        });

        function SP_EB_TOgetUsersForAppointMentPerpose() {
            $("#modalsmall").modal("show");
            $.ajax({
                url: "AddMemberShip.aspx/EB_Fetchallverifiedmembersformembership",
                type: "POST",
                data: "{'UserID':'" + UserID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                	var dt = data.d;
                	$("#modalsmall").modal("hide");
                    $("#tblAppmnt").dataTable({
                        "bDestroy": true,
                        "bRetrieve": false,
                        "sPaginationType": "full_numbers",
                        "aaData": dt,
                        "bAutoWidth": true,
                        "bDeferRender": true,
                        "aoColumns": [
                             {
                                 "mData": "Photo", 'sTitle': 'Image', "mRender": function (data) {
                                     return '<img  src="../Documents/ProfilePhoto/' + data + '" class="img-rounded" style="width:38px; height:38px;" >';
                                 }
                             },
                             {
                                 "mData": "Name", 'sTitle': 'UserName', "mRender": function (data) {
                                     return "<span>" + data + "</span>";
                                 }
                             },
                             {
                                 "mData": "Email", 'sTitle': 'UserEmail', "mRender": function (data) {
                                     return "<span>" + data + "</span>";
                                 }
                             },
                             {
                                 "mData": "Mobile", 'sTitle': 'Mobile NO', "mRender": function (data) {
                                     return "<span>" + data + "</span>";
                                 }
                             },
                              {
                                  "mData": "IndustryName", 'sTitle': 'Industry Name', "mRender": function (data) {
                                      return "<span>" + data + "</span>";
                                  }
                              },
                              {
                                  "mData": null, "sTitle": "View Details", 'mRender': function (data, type, full) {
                                      if (full.MappingID == '00000000-0000-0000-0000-000000000000') {
                                          return '<span class="glyphicon glyphicon-eye-close" data-mid=' + full.MemberID + ' onclick="ViewDetails(this);"></span>'
                                      }

                                      else {
                                          return '<span class="glyphicon glyphicon-eye-open" data-mid=' + full.MemberID + ' onclick="ViewDetails(this);"></span>'
                                      }
                                  }
                              },

                               {
                                   "mData": null, "sTitle": "View Details", 'mRender': function (data, type, full) {
                                       if (full.MemType == '1') {
                                           return 'User'
                                       }

                                       else if (full.MemType == '2') {
                                           return 'Subscriber'
                                       }
                                       else if (full.MemType == '3') {
                                           return 'Member'
                                       }
                                       else if (full.MemType == '4') {
                                           return 'Yceeyan'
                                       }
                                   }
                               }

                        ]
                    });
                   
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                }
            });
        }
        function ViewDetails(tt) {
            var id = $(tt).data("mid");
            window.location = "/Associative/ChangeMemberShip.aspx?MID=" + id + "";
        }
    </script>
</asp:Content>
