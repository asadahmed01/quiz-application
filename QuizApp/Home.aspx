<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuizApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz App</title>
   
    <style>
        body {
            background-color:#f8f9fa;
            text-align:right;
        }
        h1, h2, h4{
            font-family:sans-serif;
            font-weight:700;
            margin: 10px 0 15px 0;
        }
        footer{
            margin-top: 150px;
            color:gray;
            
        }
        #welcome{
            height: 75vh;
        }
        #opening{
            margin-bottom: 150px;
            color:lightseagreen;
        }
        #form1{
            margin-top:50px;
            margin-left:350px;
            text-align:left;
        }
        #name{
            width: 180px;
            height:30px;
            padding:5px;
            font-size:20px;
            font-family:sans-serif;
        }
        #btnSubmitName{
            margin-top:15px;
            width: 190px;
            height:45px;
            font-size:20px;
            background-color:lightseagreen;
            border:none;
            border-radius:3px;
        }
        #btnSubmitName:hover{
            background-color:lightgreen;
        }
        #before{
            color:orangered;
            margin-bottom: 35px;
        }
        .container{
           
            height:50vh;
            padding: 15px;
        }
       
        input[type=radio]{
            background-color:red;
            width: 20px;
            height:20px;
            margin-right:20px;
            margin-bottom:15px;
        }
        .item{
            font-size:25px;
        }
        .item:hover{
            background-color: #C9E6E6;
            padding:0 100px 0 0;
            border-radius:5px;
        }
        .questions{
            font-size:35px;
            padding-bottom: 20px;

        }
        .answer{
            margin-top: 25px;
             width: 90px;
            height:35px;
            font-size:20px;
            background-color:lightseagreen;
            border:none;
            border-radius:3px;
        }
        .answer:hover{
            background-color: #C9E6E6;
        }
        #timer{
            color:orangered;
        }
        #studentName{
            color:lightseagreen;

        }
        #result{
            
            font-size: 35px;
            color:lightseagreen;
        }
        table { 
                border-collapse: collapse; 
            } 
            th { 
                background-color:green; 
                Color:white; 
            } 
            th, td { 
                width:200px; 
                text-align:center; 
                border:1px solid black; 
                padding:5px 
              
            } 
       
    </style>

    <script type="text/javascript">
        var timeLeft = 20;
        //var timeLeft = document.getElementById('some').innerText;
        console.log(timeLeft);
        var timerId = setInterval(countdown, 1000);

        function countdown() {
            if (Number(timeLeft) == -1) {
                clearTimeout(timerId);

            } else {
                document.getElementById('timer').innerHTML = timeLeft + ' seconds remaining';
               <%= --num%>
                timeLeft--;
            }
            
        }
    </script>
</head>
<body>
   

    <h4 id="studentName" runat="server"></h4>
   
    
    <form id="form1" runat="server" >
        <div id="someDiv" runat="server">
            <h4 id="some" runat="server"></h4>
            <h4 id="timer" runat="server" name="time"></h4>
        </div>
         <div id="welcome" runat="server">
            <h1 id="opening">Welcome to the Quiz App</h1>
            <p id="before">Please provide your name before begining the Quiz.</p>
            <asp:TextBox runat="server" id="name" />
            <asp:RequiredFieldValidator runat="server" ID="validator" ControlToValidate="name" ErrorMessage="Name cannot be BLANK" ForeColor="Red" />
            <br />
            <asp:Button runat="server" id="btnSubmitName" text="Proceed"  OnClick="btnSubmitName_Click" />
        </div>

        
        
        

        <div id="part1" runat="server" class="container">
            <h2 id="diplay" runat="server"></h2>
            <h4 id="answer" runat="server"></h4>
            <asp:Label ID="question" runat="server" CssClass="questions"/>
            <br /> <br /> <br />
            <asp:RadioButton ID="choice1" GroupName="q1"  runat="server" CssClass="item"/> <br />
            <asp:RadioButton ID="choice2" GroupName="q1" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="choice3" GroupName="q1" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="choice4" GroupName="q1" runat="server" CssClass="item"/> <br />

            <asp:Button runat="server" id="answer1" text="Submit"  OnClick="answer1_Click" CssClass="answer"/>
        </div>

        <div id="part2" runat="server" class="container">
            <h2 id="display2" runat="server"></h2>
            
            <asp:Label ID="question2" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton1" GroupName="q2"  runat="server" CssClass="item" /> <br />
            <asp:RadioButton ID="RadioButton2" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton3" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton4" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer2" text="Submit"  OnClick="answer2_Click" CssClass="answer"/>
        </div>

        <div id="part3" runat="server" class="container">
            <h2 id="display3" runat="server"></h2>
            <asp:Label ID="question3" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton5" GroupName="q2"  runat="server" CssClass="item" /> <br />
            <asp:RadioButton ID="RadioButton6" GroupName="q2" runat="server" CssClass="item" /><br />
            <asp:RadioButton ID="RadioButton7" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton8" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer3" text="Submit"  OnClick="answer3_Click" CssClass="answer"/>
        </div>

        <div id="part4" runat="server" class="container">
            <h2 id="display4" runat="server"></h2>
            <asp:Label ID="question4" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton9" GroupName="q2"  runat="server" CssClass="item" /> <br />
            <asp:RadioButton ID="RadioButton10" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton11" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:Button runat="server" id="answer4" text="Submit"  OnClick="answer4_Click" CssClass="answer"/>
        </div>

        <div id="part5" runat="server" class="container">
            <h2 id="display5" runat="server"></h2>
            <asp:Label ID="question5" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton12" GroupName="q2"  runat="server" CssClass="item" /> <br />
            <asp:RadioButton ID="RadioButton13" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton14" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton15" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer5" text="Submit"  OnClick="answer5_Click" CssClass="answer"/>
        </div>

        <div id="part6" runat="server" class="container">
            <h2 id="dispaly6" runat="server"></h2>
            <asp:Label ID="question6" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton16" GroupName="q2"  runat="server"  CssClass="item"/> <br />
            <asp:RadioButton ID="RadioButton17" GroupName="q2" runat="server" CssClass="item" /><br />
            <asp:RadioButton ID="RadioButton18" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton19" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer6" text="Submit"  OnClick="answer6_Click" CssClass="answer"/>
        </div>

        <div id="part7" runat="server" class="container">
            <h2 id="display7" runat="server"></h2>
            <asp:Label ID="question7" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton20" GroupName="q2"  runat="server"  CssClass="item"/> <br />
            <asp:RadioButton ID="RadioButton21" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton22" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton23" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer7" text="Submit"  OnClick="answer7_Click" CssClass="answer"/>
        </div>

        <div id="part8" runat="server" class="container">
            <h2 id="display8" runat="server"></h2>
            <asp:Label ID="question8" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton24" GroupName="q2"  runat="server" CssClass="item" /> <br />
            <asp:RadioButton ID="RadioButton25" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton26" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton27" GroupName="q2" runat="server" CssClass="item"/> <br />
            <asp:Button runat="server" id="answer8" text="Submit"  OnClick="answer8_Click" CssClass="answer"/>
        </div>

        <div id="part9" runat="server" class="container">
            <h2 id="display9" runat="server"></h2>
            <asp:Label ID="question9" runat="server" CssClass="questions"/>
            <br />  <br /> <br />
            <asp:RadioButton ID="RadioButton28" GroupName="q2"  runat="server"  CssClass="item"/> <br />
            <asp:RadioButton ID="RadioButton29" GroupName="q2" runat="server"  CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton30" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:Button runat="server" id="answer9" text="Submit"  OnClick="answer9_Click" CssClass="answer"/>
        </div>

        <div id="part10" runat="server" class="questions">
            <h2 id="figure" runat="server"></h2>
            <asp:Label ID="question10" runat="server" CssClass="questions"/>
            <br />  <br /> 
            <asp:RadioButton ID="RadioButton31" GroupName="q2"  runat="server"  CssClass="item"/> <br />
            <asp:RadioButton ID="RadioButton32" GroupName="q2" runat="server" CssClass="item" /><br />
            <asp:RadioButton ID="RadioButton33" GroupName="q2" runat="server" CssClass="item"/><br />
            <asp:RadioButton ID="RadioButton34" GroupName="q2" runat="server" CssClass="item" /><br />
            <asp:Button runat="server" id="finish" text="Finish"  OnClick="finish_Click" CssClass="answer"/>
        </div>


        <div id="result" runat="server">
            <p id="test" runat="server"></p>
            <h3>Thanks For Taking The Quiz</h3>
            <p id="P1" runat="server"></p>
            <h2 id="announce" runat="server">Result: </h2>
            <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
        </div>

        <footer>
            <p>&copy; Assad Ahmed <%=DateTime.Now.Year.ToString() %></p>
        </footer>
    </form>
</body>
</html>
