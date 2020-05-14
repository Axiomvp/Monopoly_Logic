using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monopoly_Logic
{
    class Game
    {
        //Game state declaration and initialization
        private enum State { start, loading, checkturn, play };
        private State _gameState;   
        private PlayerObject _curPlayer;
        
        public Game()
        {
            _gameState = State.start;
            GameState();
        }
        //Simple finite state engine game loop, currently infinite as there is no exit clause besides closing the console
        private void GameState()
        {            
            switch (_gameState)
            {
                case State.start:
                    //init loading game files need to add network listener for client connections
                    _gameState = State.loading;
                    GameState();
                    break;

                case State.loading:
                    Players.SetNewPlayers();
                    Board.SetNewBlocks();       
                    _gameState = State.checkturn;
                    GameState();
                    break;

                case State.checkturn:
                    _curPlayer = Players.CheckTurn();
                    _gameState = State.play;
                    GameState();
                    break;

                case State.play:
                    _gameState = State.checkturn;
                    Console.WriteLine("==============================================================");
                    Console.WriteLine("========================Start Turn============================");
                    Console.WriteLine($"It is now Player {_curPlayer.index} turn");
                    Turn turn = new Turn(_curPlayer);
                    Console.WriteLine("=========================End Turn=============================");
                    GameState();
                    break;
            }
        }
    }
}
