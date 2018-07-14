<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineTest._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script>
		$(function () {

			function start() {
				$.ajax({
					url: 'api/combat/start',
					type: 'POST',
					contentType: "application/json;charset=utf-8",
					success: function (data) {
						vm.combat(data);
					},
					error: function (data) {
					}
				});
			}
			function attack() {
				$.ajax({
					url: 'api/combat/attack',
					type: 'POST',
					contentType: "application/json;charset=utf-8",
					success: function (data) {
						vm.combat(data);
					},
					error: function (data) {
					}
				});
			}

			var vm = {
				combat: ko.observable(),
				start: start,
				attack: attack
			}
			
			ko.applyBindings(vm);
		});
</script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


	<div class="row">
		<button data-bind="click: start">Start</button>
		<button data-bind="click: attack">Go</button>
		<div data-bind="if: combat()">
			<label data-bind="text: combat().PlayerHp"></label>
			<label data-bind="text: combat().NPCHp"></label>
		</div>
	</div>

</asp:Content>
