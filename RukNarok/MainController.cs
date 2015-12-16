using System;
using System.Windows.Forms;
using System.Drawing;

namespace RukNarok
{
    public class MainController : Controller
    {
        public enum Warp
        {
            LEFT,
            RIGHT
        };
        public Warp WarpDirection;
        
        public MainController()
        {
            
        }
        
        public override void ToggleMenu()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.MenuStatus = (mainModel.MenuStatus ? false : true);
                    mainModel.MenuStatusChanging = true;
                    mainModel.Update();
                }
            }
        }

        public override void MapChanged(int newMap)
        {
            foreach (Model model in ModelList)
            {
                if (model is MapModel)
                {
                    MapModel mapModel = (MapModel)model;
                    if (newMap >= 0 && newMap <= 4)
                    {
                        mapModel.CurrentMap = newMap;
                        mapModel.Update();
                    }
                }
            }
        }

        public void PlayerDirectionChanged(Direction direction)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerCharacter.Direction = direction;
                }
            }
        }

        public void PlayerWalkingPressed(Keys key)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerPressedKeyDown = key;
                    mainModel.PlayerCharacter.Moving = true;
                    switch (key)
                    {
                        case Keys.Up:
                            {
                                mainModel.PlayerMovingDirection[2] = true;
                                break;
                            }
                        case Keys.Down:
                            {
                                mainModel.PlayerMovingDirection[8] = true;
                                break;
                            }
                        case Keys.Left:
                            {
                                mainModel.PlayerMovingDirection[4] = true;
                                break;
                            }
                        case Keys.Right:
                            {
                                mainModel.PlayerMovingDirection[6] = true;//Convert.ToInt16(Direction.East)
                                break;
                            }
                    }
                }
            }
        }

        public void PlayerWalkingReleased(Keys key)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerPressedKeyUp = key;
                    mainModel.PlayerCharacter.Moving = true;
                    switch (key)
                    {
                        case Keys.Up:
                            {
                                mainModel.PlayerMovingDirection[Convert.ToInt16(Direction.North)] = false;
                                break;
                            }
                        case Keys.Down:
                            {
                                mainModel.PlayerMovingDirection[Convert.ToInt16(Direction.South)] = false;
                                break;
                            }
                        case Keys.Left:
                            {
                                mainModel.PlayerMovingDirection[Convert.ToInt16(Direction.West)] = false;
                                break;
                            }
                        case Keys.Right:
                            {
                                mainModel.PlayerMovingDirection[Convert.ToInt16(Direction.East)] = false;
                                break;
                            }
                    }
                }
            }
        }

        public void PlayerMoved(Direction direction)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    switch (direction)
                    {
                        case Direction.North:
                            {
                                mainModel.PlayerMovingDirection[2] = false;
                                break;
                            }
                        case Direction.South:
                            {
                                mainModel.PlayerMovingDirection[8] = false;
                                break;
                            }
                        case Direction.West:
                            {
                                mainModel.PlayerMovingDirection[4] = false;
                                break;
                            }
                        case Direction.East:
                            {
                                mainModel.PlayerMovingDirection[6] = false;
                                break;
                            }
                    }
                    mainModel.Update();
                }
            }
        }
   
        public void PlayerStartAttack()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerCharacter.Attacking = true;
                    mainModel.Update();
                }
            }
        }

        public void PlayerStopAttack()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerCharacter.Attacking = false;
                    mainModel.Update();
                }
            }
        }

        public void Monster1IsAttacked()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    //mainModel.MonsterCharacter.IsAttacked = true;
                    //if (!mainModel.MonsterCharacter.HealthBar) mainModel.MonsterCharacter.HealthBar = true;
                    mainModel.Update();
                }
            }
        }

        public void PlayerStartBattle(Monster monster)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "Battle";
                    mainModel.MonsterBattle = monster;
                    mainModel.Update();
                }
            }
            foreach (Model model in ModelList)
            {
                if (model is MapModel)
                {
                    MapModel mapModel = (MapModel)model;
                    mapModel.Update();
                }
            }
        }

        public void PlayerStopBattle()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "Main";
                    mainModel.BattleStatus = "EndToMain";
                    mainModel.MonsterBattle = null;
                    mainModel.Update();
                }
            }
        }

        public void PlayerLevelUp()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.PlayerCharacter.Level++;
                    mainModel.PlayerCharacter.EXP = 0;
                }
            }
        }

        public void CharacterChangeHealth(Character character, int hp)
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    if (character is Player)
                    {
                        ((Player)character).HP += hp;
                    }
                    else if (character is Monster)
                    {
                        ((Monster)character).HP += hp;
                    }
                    mainModel.Update();
                }
            }
        }

        public void StartGame()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "StartGame";
                    mainModel.Update();
                }
            }
        }

        public void LoadingGame()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "Loading";
                    mainModel.Update();
                }
            }
        }

        public void MainGame()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "Main";
                    mainModel.Update();
                }
            }
        }

        public void PlayerWarp(Warp warp)
        {
            foreach (Model model in ModelList)
            {
                if (model is MapModel)
                {
                    MapModel mapModel = (MapModel)model;
                    switch (warp)
                    {
                        case Warp.LEFT:
                            if (mapModel.CurrentMap > 0) mapModel.CurrentMap--;
                            break;
                        case Warp.RIGHT:
                            mapModel.CurrentMap++;
                            break;
                        default:
                            break;
                    }
                    mapModel.Update();
                }
            }
        }

        public void GameOver()
        {
            foreach (Model model in ModelList)
            {
                if (model is MainModel)
                {
                    MainModel mainModel = (MainModel)model;
                    mainModel.GameStatus = "GameOver";
                    mainModel.Update();
                }
            }
        }
    }
}
