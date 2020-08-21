using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe_book
{
    public class MenuActionService
    {
         public List<MenuAction> menuActions = new List<MenuAction>();
     
        /// <summary>
        /// dopisanie do listy Menu  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actionName"></param>
        /// <param name="menuName"></param>
        public void AddNewAction(int id, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, ActionName = actionName, MenuName = menuName };
            menuActions.Add(menuAction);
        }
        /// <summary>
        /// zwraca pozycje Menu po podaniu nazwy Menu
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();

            foreach (var menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}
