using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RukNarok
{
    public class MainController : Controller
    {
        public const int MapZero = 0;
        public const int MapOne = 1;
        public const int MapTwo = 2;
        
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

        public override void MapChanged(int action)
        {
            foreach (Model model in ModelList)
            {
                if (model is MapModel)
                {
                    MapModel mapModel = (MapModel)model;
                    if (action >= MapZero && action <= MapTwo)
                    {
                        mapModel.CurrentMap = action;
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
                    mainModel.MonsterCharacter.IsAttacked = true;
                    if (!mainModel.MonsterCharacter.HealthBar) mainModel.MonsterCharacter.HealthBar = true;
                    mainModel.Update();
                }
            }
        }
    }
}
