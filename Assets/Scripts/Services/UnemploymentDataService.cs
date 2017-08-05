using System;
using System.Collections.Generic;
using UnityEngine;

public class UnemploymentDataService
{

    static string data = @"New Mexico	 62445	 927359	 0.0673363821	 1
 Louisiana	 129105	 2121226	 0.0608633875	 1
 District Of Columbia	 23602	 392448	 0.0601404517	 1
 West Virginia 47043 783468 0.0600445711 1
 Alabama	 129835	 2168612	 0.059870092	 1
 Illinois	 384145	 6539021	 0.0587465616	 2
 Mississippi	 74660	 1280438	 0.0583081727	 2
 Nevada	 81105	 1427113	 0.0568315193	 2
 Pennsylvania	 351962	 6471996	 0.0543822957	 2
 Washington	 198002	 3643885	 0.0543381583	 2
 California	 1037687	 19102734	 0.0543213867	 3
 Georgia	 264211	 4920469	 0.0536963042	 3
 Rhode Island	 29408	 552220	 0.0532541378	 3
 Arizona	 171600	 3237865	 0.052997886	 3
 Wyoming	 15960	 302335	 0.0527891246	 3
 Connecticut	 96272	 1891790	 0.0508893693	 4
 North Carolina	 246377	 4875712	 0.0505314916	 4
 Alaska	 224328	 4524260	 0.0495833573	 4
 Kentucky	 99701	 1991981	 0.0500511802	 4
 New Jersey	 224328	 4524260	 0.0495833573	 4
 Ohio	 282301	 5713093	 0.0494129887	 4
 Michigan	 237716	 4836771	 0.0491476648	 5
 Florida	 480368	 9838942	 0.0488231357	 5
 Oregon	 100296	 2055120	 0.0488029896	 5
 Oklahoma	 89054	 1828423	 0.0487053598	 5
 South Carolina	 111070	 2297814	 0.0483372457	 5
 New York	 463131	 9584458	 0.0483210423	 6
 Tennessee	 150842	 3135102	 0.0481139051	 6
 Texas	 612837	 13284651	 0.0461312081	 6
 Missouri	 140817	 3111525	 0.0452565864	 6
 Indiana	 147091	 3326905	 0.0442125639	 6
 Delaware	 20704	 472677	 0.0438015812	 7
 Maryland	 135881	 3170012	 0.0428645065	 7
 Kansas	 61889	 1484012	 0.0417038407	 7
 Montana	 21830	 526407	 0.0414698133	 7
 Wisconsin	 129201	 3120236	 0.0414074448	 7
 Virginia	 170151	 4240416	 0.0401260159	 8
 Arkansas	 53698	 1342695	 0.0399927012	 8
 Minnesota	 117046	 3001146	 0.0390004352	 8
 Maine	 26615	 690624	 0.0385376124	 8
 Idaho	 31140	 814575	 0.0382285241	 8
 Massachusetts	 132786	 3588613	 0.0370020395	 9
 Iowa	 62404	 1700696	 0.0366932127	 9
 Utah	 51762	 1511467	 0.0342461992	 9
 Colorado	 95814	 2891051	 0.0331415807	 9
 Vermont	 11252	 344889	 0.0326249895	 9
 Nebraska	 32478	 1011051	 0.0321230086	 10
 North Dakota	 13161	 416230	 0.0316195373	 10
 Hawaii	 20689	 685380	 0.0301861741	 10
 New Hampshire	 21149	 748566	 0.0282526858	 10
 South Dakota	 12412	 449427	 0.0276173884	 10";


    public static List<UnemploymentData> UnemploymentDataList
    {

        get
        {
            // cleaning up teh data
            data = data.Replace('\t', ' ');
            data = data.Replace("  ", " ");

            var unemploymentDataList = new List<UnemploymentData>();
            var lines = data.Split('\n');

            foreach (var line in lines)
            {
                var words = line.Split(' ');


                int i = words.Length - 1;

                int decile = int.Parse(words[i]);
                float rate = float.Parse(words[i - 1]);
                int civil_force = int.Parse(words[i - 2]);
                int unemployed_pop = int.Parse(words[i - 3]);

                string state = "";

                for (int j = 0; j <= i - 4; j++)
                {
                    state += words[j] + " ";
                }

                state = state.Trim();

                unemploymentDataList.Add(new UnemploymentData(state, unemployed_pop, civil_force, rate, decile));

            }

            return unemploymentDataList;
        }

    }


}
