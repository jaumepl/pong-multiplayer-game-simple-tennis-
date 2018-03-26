using System;
using System.Threading;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using personal.Hubs;

namespace tennis1
{
    public class TennisGame
    {
        public int Alt_Y { get; set; }

        public int Ample_X { get; set; }

        public float ballX { get; set; }
        public float ballY { get; set; }
        public float ballSpeedX { get; set; }
        public float ballSpeedY { get; set; }
        public float palaDreta { get; set; }
        public float palaEsquerra { get; set; }
        public bool inicialized { get; set; }

        public TennisGame(int tAmple_X, int tAlt_Y, float tballX, float tballY,
                        float tballSpeedX, float tballSpeedY, bool tinicialized)
        {
            Ample_X = tAmple_X;
            Alt_Y = tAlt_Y;
            ballX = tballX;
            ballY = tballY;
            ballSpeedX = tballSpeedX;
            ballSpeedY = tballSpeedY;
            inicialized = tinicialized;
        }

        public void start()
        {
            palaDreta = Alt_Y / 2;
            palaEsquerra = Alt_Y / 2;
            while (!Program.SharedObj.inicialized)
            {
                Thread.Sleep(1000);
            }

            while (true)
            {
                Thread.Sleep(10);
                //nova posició, suma delta
                float deltaX = ballSpeedX;
                float deltaY = ballSpeedY;
                ballX = ballX + deltaX;
                ballY = ballY + deltaY;
                //Topalls
                if (ballX >= Ample_X)
                {
                    ballSpeedX = -ballSpeedX;
                    ballX = Ample_X;

                }
                if (ballY >= Alt_Y)
                {
                    ballSpeedY = -ballSpeedY;
                    ballY = Alt_Y;
                }
                if (ballX <= 0)
                {
                    //de moment tot rebota
                    ballSpeedX = -ballSpeedX;
                    ballX = 0;
                }
                if (ballY <= 0)
                {
                    ballSpeedY = -ballSpeedY;
                    ballY = 0;
                }
                if (Program.globalHubContext != null)
                {
                    Program.globalHubContext.Clients.All.SendAsync("setGamePositions", (Program.SharedObj.palaEsquerra, 0, ballX, ballY));
                }
                //leftMouseX, leftMouseY, rigthMouseX, rightMouseY, ballPosX, ballPosY
            }
            // public float leftRacketX { get; set; }
            // public float leftRacketY { get; set; }
            // public float rightRacketX { get; set; }
            // public float rightRacketY { get; set; }
            // public bool winningScreenShowed { get; set; }
            // public bool stopped { get; set; }
            // public bool requestId { get; set; }
            // public static int computerLevel = 9; //range 0 - 10
            // public float player1Score { get; set; }
            // public float player2Score { get; set; }
            // private int WINNING_SCORE = 3;
            // private int PADDLE_HEIGHT = 100;
            // private int PADDLE_THICKNESS = 10;

            // public void loop()
            // {
            //     if (!stopped) {
            //     moveEverything();
            //     }
            // }

            // public void start() {
            //     stopped = false;
            // }

            // function stop() {
            //     if (requestId) {
            //     window.cancelAnimationFrame(requestId);
            //     }
            //     stopped = true;
            // }

            // start();

            // canvas.addEventListener('mousemove', function(e){
            //     var mousePos = calculateMousePos(e);
            //     paddle1Y = mousePos.y - (PADDLE_HEIGHT/2);
            // });

            // canvas.addEventListener('click', function(){
            //     if(!winningScreenShowed){
            //     return;
            //     }
            //     winningScreenShowed = false;
            //     playerScore = 0;
            //     computerScore = 0;
            // });

            // function getRadomNumber(min, max){
            //     return Math.random() * (max - min) + min;
            // }


            // public void moveEverything(){   
            //     if(winningScreenShowed){
            //     return;
            //     }
            //     var hitThePaddle1 = (ballY > paddle1Y && ballY < paddle1Y + PADDLE_HEIGHT);
            //     var hitThePaddle2 = (ballY > paddle2Y && ballY < paddle2Y + PADDLE_HEIGHT);
            //     computerMovement();
            //     ballX = ballX + ballSpeedX;//del servidor
            //     ballY = ballY + ballSpeedY;
            //     if(ballX > W-20){
            //     if(hitThePaddle2){
            //         ballSpeedX = -ballSpeedX;
            //     }else if(ballX > W){
            //                 playerScore++;
            //         resetBall();
            //     }
            //     }
            //     if(ballX < 20){
            //     if(hitThePaddle1){
            //         ballSpeedX = -ballSpeedX;
            //         var deltaY = ballY - (paddle1Y + (PADDLE_HEIGHT/2));
            //         ballSpeedY = deltaY * 0.2;
            //     }else if(ballX < 0){
            //         computerScore++;
            //         resetBall();
            //         stop();
            //         setTimeout(function(){
            //         start();
            //         }, 1000);
            //     }
            //     }
            //     if(ballY > H){
            //     ballSpeedY = -ballSpeedY;
            //     }
            //     if(ballY < 0){
            //     ballSpeedY = -ballSpeedY;
            //     }
            // };

            // function drawNet(){
            //     for(var i = 0; i < H; i+=40){
            //     drawRect(W/2-1, i, 2, 20, 'white');
            //     }
            // };

            // function drawEverything(){
            //     drawRect(0, 0, W, H, 'white');
            //     drawNet();    
            //     drawRect(0, paddle1Y, PADDLE_THICKNESS, PADDLE_HEIGHT, 'red');
            //     drawRect(W-PADDLE_THICKNESS, paddle2Y, PADDLE_THICKNESS, PADDLE_HEIGHT, 'grey');
            //     drawCircle(ballX, ballY, 5, 'black');
            //     if(winningScreenShowed){
            //     ctx.fillStyle = 'black';
            //     if(playerScore == WINNING_SCORE){
            //         ctx.fillText('Has guanyat!', 100, 100);
            //     }else if(computerScore >= WINNING_SCORE){
            //         ctx.fillText('Ha guanyat l´ordinador!', W-150, 100);  
            //     }
            //     ctx.fillText('click per continuar', 300, 310);
            //     return;
            //     }
            //     ctx.fillStyle = 'black';
            //     ctx.fillText(playerScore, 100, 100);
            //     ctx.fillText(computerScore, W-100, 100);
            // }

            // function drawRect(x, y, w, h, color){
            //     ctx.fillStyle = color;
            //     ctx.fillRect(x, y, w, h);
            // }

            // function drawCircle(x, y, rad, color){
            //     ctx.fillStyle = color;
            //     ctx.beginPath();
            //     ctx.arc(x, y, rad, 0, Math.PI * 2, false);
            //     ctx.fill();
            // }

            // function calculateMousePos(e){
            //     var rect = canvas.getBoundingClientRect();
            //     var root = document.documentElement;
            //     var mouseX = e.clientX - rect.left - root.scrollLeft;
            //     var mouseY = e.clientY - rect.top - root.scrollTop;
            //     return {
            //     x: mouseX,
            //     y: mouseY
            //     }
            // }

            // function resetBall(){
            //     if(playerScore == WINNING_SCORE || computerScore == WINNING_SCORE){
            //     winningScreenShowed = true;
            //     }
            //     ballX = W/2;
            //     ballY = H/2;
            //         ballSpeedY = 0;
            //     paddle2Y = 150;
            //     paddle1Y = 150;
            // }
        }
    }
}