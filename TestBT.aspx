<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestBT.aspx.cs" Inherits="TestBT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="container">
  <h2>Glyphicon Examples</h2>
  <p>Envelope icon: <span class="glyphicon glyphicon-envelope"></span></p>    
  <p>Envelope icon as a link:
    <a href="#"><span class="glyphicon glyphicon-envelope"></span></a>
  </p>
  <p>Search icon: <span class="glyphicon glyphicon-search"></span></p>
  <p>Search icon on a button:
    <button type="button" class="btn btn-default">
      <span class="glyphicon glyphicon-search"></span> Search
    </button>
  </p>
  <p>Search icon on a styled button:
    <button type="button" class="btn btn-info">
      <span class="glyphicon glyphicon-search"></span> Search
    </button>
  </p>
  <p>Print icon: <span class="glyphicon glyphicon-print"></span></p>      
  <p>Print icon on a styled link button:
    <a href="#" class="btn btn-success btn-lg">
      <span class="glyphicon glyphicon-print"></span> Print 
    </a>
  </p> 
</div>
         <div class="form-group">
      <label for="pwd">Password:</label>
      <input type="password" class="form-control" id="pwd" placeholder="Enter password">
    </div>
    </form>
</body>
</html>
