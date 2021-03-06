﻿using BenchmarkDotNet.Attributes;
using Decent.Minecraft.Client;
using Decent.Minecraft.Client.Blocks;
using Decent.Minecraft.Client.Java;
using System;

namespace Decent.Minecraft.Benchmark
{
    public class Blocks
    {
        public IWorld World { get; set; }
        public Random Rnd { get; private set; }

        [Setup]
        public void Setup()
        {
            World = JavaWorld.Connect();
            Rnd = new Random();
        }

        [Cleanup]
        public void Cleanup()
        {
            World.Dispose();
            World = null;
        }

        [Benchmark]
        public void GetBlock()
        {
            World.GetBlock(0, 0, 0);
        }

        [Benchmark]
        public void SetBlocksSame()
        {
            var block = new Air();
            World.SetBlock(block, 0, 0, 0);
        }

        [Benchmark]
        public void SetBlocksDifferent()
        {
            var block = new UnknownBlock((BlockType)Rnd.Next(248));
            World.SetBlock(block, 0, 0, 0);
        }
    }
}
