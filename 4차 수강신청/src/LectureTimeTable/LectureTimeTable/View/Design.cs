using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableView
{
    public class Design
    {
        public void PrintMain()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t      :::        ::::::::::       ::::::::   :::::::::::      :::    :::       :::::::::       ::::::::::");
            Console.WriteLine("\t     :+:        :+:             :+:    :+:      :+:          :+:    :+:       :+:    :+:      :+:        ");
            Console.WriteLine("\t    +:+        +:+             +:+             +:+          +:+    +:+       +:+    +:+      +:+         ");
            Console.WriteLine("\t   +#+        +#++:++#        +#+             +#+          +#+    +:+       +#++:++#:       +#++:++#     ");
            Console.WriteLine("\t  +#+        +#+             +#+             +#+          +#+    +#+       +#+    +#+      +#+           ");
            Console.WriteLine("\t #+#        #+#             #+#    #+#      #+#          #+#    #+#       #+#    #+#      #+#            ");
            Console.WriteLine("\t########## ##########       ########       ###           ########        ###    ###      ##########      \n");
            Console.WriteLine("\t                     :::::::::::       :::::::::::         :::   :::       ::::::::::  ");
            Console.WriteLine("\t                        :+:               :+:            :+:+: :+:+:      :+:          ");
            Console.WriteLine("\t                       +:+               +:+           +:+ +:+:+ +:+     +:+           ");
            Console.WriteLine("\t                      +#+               +#+           +#+  +:+  +#+     +#++:++#       ");
            Console.WriteLine("\t                     +#+               +#+           +#+       +#+     +#+             ");
            Console.WriteLine("\t                    #+#               #+#           #+#       #+#     #+#              ");
            Console.WriteLine("\t                  ###           ###########       ###       ###     ##########        \n");
            Console.WriteLine("\t                :::::::::::           :::        :::::::::       :::          :::::::::: ");
            Console.WriteLine("\t                   :+:             :+: :+:      :+:    :+:      :+:          :+:         ");
            Console.WriteLine("\t                  +:+            +:+   +:+     +:+    +:+      +:+          +:+          ");
            Console.WriteLine("\t                 +#+           +#++:++#++:    +#++:++#+       +#+          +#++:++#      ");
            Console.WriteLine("\t                +#+           +#+     +#+    +#+    +#+      +#+          +#+            ");
            Console.WriteLine("\t               #+#           #+#     #+#    #+#    #+#      #+#          #+#             ");
            Console.WriteLine("\t              ###           ###     ###    #########       ##########   ##########      \n");
        }
        public void PrintBox(int line)
        {
            
            Console.WriteLine("\t         ┌─────────────────────────────────────────────────────────────────────────────┐");
            for(int i = 0; i < line; i++)
            {
                Console.WriteLine("\t         │                                                                             │");
            }
            Console.WriteLine("\t         └─────────────────────────────────────────────────────────────────────────────┘");
        }
    }
}