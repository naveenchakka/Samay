<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="send-bulk-sms.aspx.cs" Inherits="Aspfiles_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content container">
      <div class="row">
        <div class="col-md-12">
          <h2 class="page-title">SMS</h2>
        </div>
      </div>
      <div class="row">
        <div class="col-lg-6">
          <div class="widget">
            <div class="widget-header"> <i class="icon-align-left"></i>
              <h3>Send Bulk SMS </h3>
            </div>
            <div class="widget-content">
            <div class="form-horizontal">
              <div class="col-lg-12">
                <fieldset>
                 
                  <div class="form-group">
                    <label for="dropdown-appended">File Name</label>
                    <div class="input-group1">
                      <input type="text" id="dropdown-appended" class="form-control">
                    </div>
                      
                  </div>
                  <div class="form-group">
                    <label for="normal-field" class="control-label1">Upload only .csv/.txt file</label>
                    <div class="input-group">
                      <input type="file" placeholder="Stylish, huh??" id="transparent-field">
                    </div>
                  </div>
                 
                </fieldset>
                <div class="form-actions">
                  <div>
                    <button class="btn btn-primary" type="submit">Upload</button>
                    <button class="btn btn-default" type="reset">Reset</button>
                  </div>
                </div>
              </div><!-- Clm1 end -->
                
                
                  
              </div>
              
              
            </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>

