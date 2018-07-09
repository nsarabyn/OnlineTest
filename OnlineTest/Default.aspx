<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineTest._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script>
		$(function () {

			function start() {
				$.ajax({
					url: 'api/combat/start/1',
					type: 'POST',
					contentType: "application/json;charset=utf-8",
					success: function () {
					},
					error: function (data) {
					}
				});
			}

			var vm = {
				start: start
			}
			
			ko.applyBindings(vm);
		});
</script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>ASP.NET</h1>
		<p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
		<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
	</div>

	<div class="row">
		<button data-bind="click: start">Start</button>
	</div>

</asp:Content>
