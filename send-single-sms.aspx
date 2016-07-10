<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Send-single-sms.aspx.cs" Inherits="Aspfiles_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="content container">
      <div class="row">
        <div class="col-md-12">
          <h2 class="page-title">SMS</h2>
        </div>
      </div>
      <div class="col-lg-12" style="padding-left:0px; padding-right:0px;">
          <div class="widget">
            <div class="widget-header"> <i class="icon-align-right"></i>
              <h3>Send Single Sms</h3>
            </div>
            <div class="widget-content">
              <div>
              <div class="col-lg-6">
                  
                <fieldset>
                  <!-- //<legend class="section">Default form</legend> -->
                  
                  <asp:Panel ID="Panel2" runat="server" >
                  <div class="form-group">
                     <label for="bar">Carrier ID</label>
                      <div class="input-group">
                      <div class="input-group-btn">
                      <asp:DropDownList ID="ddl_carriercode" class="bset form-control" runat="server" AutoPostBack="True" Width="71px" ></asp:DropDownList>
                          </div>
                          &nbsp;<asp:LinkButton ID="lbtnSetDefault" runat="server" class="topMrgn">Set as default</asp:LinkButton>
                          </div>
                      <label for="bar">Sender ID</label>
                    <div class="input-group">
                      <div class="input-group-btn">
                          <asp:DropDownList ID="ddl_senderids" class="bset form-control" runat="server" Width="169px"></asp:DropDownList>
                          <%--  <button data-toggle="dropdown" class="bset form-control"> Select Sender ID<i class="icon-caret-down"></i> </button>--%>
                        <ul class="dropdown-menu dropdown-menuCstm">
                          <li><a href="#">CONTXT</a></li>
                        </ul>
                      </div>&nbsp;<a href="#" class="topMrgn">Set as default</a>
                    
                    
                    </div>
                  </div>
                  <div class="form-group">
                    <label for="dropdown-appended">To Mobile No</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtmobileno" runat="server" ></asp:TextBox>
                        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RFVtxtmobileno" runat="server" ControlToValidate="txtmobileno" ErrorMessage="*" Font-Bold="true" Font-Italic="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVtxtmobileno" runat="server" ControlToValidate="txtmobileno" Text="EX: 9966123123" Font-Bold="true" Font-Italic="true" ForeColor="Red" ValidationExpression="^((\\+91-?)|0)?[0-9]{10}$"></asp:RegularExpressionValidator>
                     </div>
                  </div>
                  <div class="form-group">
                    <label for="bar">Templates</label>
                    <div class="input-group">
                      <div class="input-group-btn">
                          <asp:DropDownList ID="ddl_templates" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_templates_SelectedIndexChanged" class="bset form-control" Width="172px"></asp:DropDownList>
                          <%--  <button data-toggle="dropdown" class="bset form-control"> Select Template<i class="icon-caret-down"></i> </button>--%>
                        <ul class="dropdown-menu">
                          <li><a href="#">CONTXT</a></li>
                        </ul>
                      </div>&nbsp;<a href="#" class="topMrgn">Set as default</a>
                    
                    
                    </div>
                  </div>
                      <div class="form-group">
                          <label for="dropdown-appended">Message</label>
                          <div class="input-group">
                              <asp:TextBox ID="txtmessage" runat="server" class="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox>
                              &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RFVtxtmessage" runat="server" ControlToValidate="txtmessage" ErrorMessage="*" Font-Bold="true" Font-Italic="true" ForeColor="Red"></asp:RequiredFieldValidator>
                              <%--       <textarea class="form-control" name="text" rows="3" id="Textarea1"></textarea>--%>
                              <span class="help-block">*Don't copy &amp; paste content from word file or from email</span>
                              <div class="btn-bottom">
                                  <asp:Button ID="btnmsgclear" runat="server" Text="Clear" class="btnpad btn btn-sm btn-default" CausesValidation="false" OnClick="btnmsgclear_Click" />
                              </div>
                          </div>
                      </div>

					 <%--<div class="form-group">
                    <div class="input-group">
                     <div class="input-group-btn">
                        <button data-toggle="dropdown" class="bset1 form-control"> English<i class="icon-caret-down"></i> </button>
                        <ul class="dropdown-menu">
                          <li><a href="#">CONTXT</a></li>
                        </ul>
                      </div>
                        <asp:Button ID="btnmblnoclear" runat="server"  Text="Clear" class="btn btn-sm btn-default" OnClick="btnmblnoclear_Click" CausesValidation="false" />
                      
                    </div>
                  <span class="help-block1">0 Characters. 0 Credits.</span><span class="right help-block1">Max chars-1000</span>
                  </div>--%>
                  <div class="form-group">
                    <div class="input-group">
                      <input type="text" placeholder="Enter Compaign Name" id="type-dropdown-appended" class="form-control">
                   </div>
                        <%--<span class="help-block1">Flash Message</span>&nbsp;<span><input type="checkbox" value="1" name="remember"></span>&nbsp;--%>
                      <span class="help-block1">Schedule Message</span>&nbsp;<span><input type="checkbox" value="1" name="remember"></span>
                  </div>
                    <div>
                        <%-- <button class="btncenter btn btn-primary" type="submit">Preview</button>  --%>
                        <asp:Button ID="btnpreview" runat="server" Text="Preview" class="btncenter btn btn-primary" OnClick="btnpreview_Click" />
                       
                    </asp:Panel>
            		    <br />
                           <%--<asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="SenderID :"></asp:Label>--%>

                     <asp:Panel ID="Panel1" runat="server">
                    <div class="form-group">

                            <label for="bar">Carrier ID : </label>
                            <asp:Label ID="lbldisplaycarrierid" runat="server" Text=""></asp:Label>
                            <div >
                                <label for="bar">Sender ID : </label>
                                <asp:Label ID="lbl_senderid" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <label for="dropdown-appended">MobileNo : </label>
                                <asp:Label ID="lbl_mblno" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <label for="dropdown-appended">Message : </label>
                                <asp:Label ID="lbl_templatemsg" runat="server" Text=""></asp:Label>
                            </div>
                            <%--<div>
                                <label for="dropdown-appended">Campaign : </label>
                                <asp:Label ID="lbldisplayCampname" runat="server" Text=""></asp:Label>
                            </div>--%>
                        <br />
                            <div>
                                <asp:Button ID="btnsend" runat="server" Text="Send" class="btncenter btn btn-primary" OnClick="btnsend_Click"/>
                                <asp:Button ID="btncancel" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btncancel_Click"/>
                            </div>
                    </asp:Panel>
            		</div> 

                </fieldset>
                </div>
                
              <div class="col-lg-6">
                <fieldset>
                  <!-- //<legend class="section">Default form</legend> -->
                  
                 
                  
                 <%-- <div class="form-group">
                    <div class="input-group">
                      <input type="text" placeholder="Search Here" id="Text1" class="form-control">
                   </div>
<span class="help-block">List Of Groups</span>
<span><input type="checkbox" value="1" name="remember">&nbsp;<span class="help-block1">Unreserved(0)</span></span>
                  </div>--%>
                     
                  </fieldset>
                </div>
              
              
              
              </div>
              
              
            </div>
          </div>
        </div>
      </div>
</asp:Content>

