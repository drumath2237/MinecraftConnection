﻿using System;
using MinecraftConnection;
using MinecraftConnection.Items;

namespace ExampleApp
{
    class Program
    {
        static string address = "127.0.0.1";
        static readonly ushort port = 25575;
        static readonly string password = "minecraft";
        static MinecraftCommands commands = new MinecraftCommands(address, port, password);

        static void Main(string[] args)
        {
            string result = commands.SendCommand("time set midnight");

            // Azure用の座標
            /*int x = -52 - 40;
            int y = 68;
            int z = 92;*/

            // Local用の座標
            int x = -961 + 20;
            int y = 70;
            int z = -798;

            while (true)
            {
                Kiku(x, y, z, 30);
                commands.Wait(2000);
            }

        }

        static void Kiku(int x, int y, int z, int time)
        {
            Fireworks fireworksIn = new Fireworks(time, 2, FireworksShapes.SmallBall, false, true, FireworksColors.RED, FireworksColors.RED);
            Fireworks fireworksOut = new Fireworks(time, 2, FireworksShapes.LargeBall, false, true, FireworksColors.ORANGE, FireworksColors.ORANGE);
            commands.SetOffFireworks(x, y, z, fireworksOut);
            commands.SetOffFireworks(x, y, z, fireworksIn);
            commands.Wait(1000);

            fireworksIn = new Fireworks(time, 2, FireworksShapes.SmallBall, false, true, FireworksColors.GREEN, FireworksColors.GREEN);
            fireworksOut = new Fireworks(time, 2, FireworksShapes.LargeBall, false, true, FireworksColors.LIME, FireworksColors.LIME);
            commands.SetOffFireworks(x, y, z + 14, fireworksOut);
            commands.SetOffFireworks(x, y, z + 14, fireworksIn);
            commands.Wait(1000);

            fireworksIn = new Fireworks(time, 2, FireworksShapes.SmallBall, false, true, FireworksColors.BLUE, FireworksColors.BLUE);
            fireworksOut = new Fireworks(time, 2, FireworksShapes.LargeBall, false, true, FireworksColors.LIGHTBLUE, FireworksColors.LIGHTBLUE);
            commands.SetOffFireworks(x, y, z + 28, fireworksOut);
            commands.SetOffFireworks(x, y, z + 28, fireworksIn);
        }
    }
}