<%@ Page Language="C#" Inherits="RiskHunting.DefaultRedirectErrorPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
	<title>DefaultRedirect Error Page</title>
	<link href="Theme/css/error.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">

	<div>
		<h1>We’re sorry — something has gone wrong on our end.</h1>
	</div>
	<div >
		<div>
			<h2>What could have caused this?</h2>
			<ul>
				<li>Well, something technical went wrong on our site.</li>
				<li>We might have removed the page when we redesigned our website.</li>
				<li>Or the link you clicked might be old and does not work anymore.</li>
				<li>Or you might have accidentally typed the wrong URL in the address bar.</li>
			</ul>

			<h2>What you can do?</h2>
			<ul>
				<li>You might try retyping the URL and trying again.</li>
				<li>Or we could take you back to the <a href='DescribeRisk.aspx'> home page</a>. </li>
				<li>In any case, an email has been sent to the site owner to report the problem.</li>
			</ul>

			<p>
				<strong>One more thing:</strong><br>
				If you want to help us fix this issue, we are here to help. Please contact us and let us know what went wrong.
			</p>
		</div>
		 
	</div>
  </form>
</body>
</html>