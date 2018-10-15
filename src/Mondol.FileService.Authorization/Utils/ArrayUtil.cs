// Copyright (c) Mondol. All rights reserved.
// 
// Author:  frank
// Email:   frank@mondol.info
// Created: 2016-11-17
// 
using System;
using System.Linq;

namespace Mondol.Utils
{
    public static class ArrayUtil
    {
        /// <summary>
        /// 返回多个数组相加后的新数组
        /// </summary>
        public static byte[] Addition(params Array[] byteses)
        {
            var totalLen = byteses.Sum(p => p.Length);
            var bysRetn = new byte[totalLen];
            var index = 0;
            foreach (var bytes in byteses)
            {
                Array.Copy(bytes, 0, bysRetn, index, bytes.Length);
                index += bytes.Length;
            }
            return bysRetn;
        }

        public static bool Equals(byte[] array1, int array1Index, byte[] array2, int array2Index, int length)
        {
            if (array1Index + length > array1.Length)
                throw new ArgumentOutOfRangeException(nameof(array1));
            if (array2Index + length > array2.Length)
                throw new ArgumentOutOfRangeException(nameof(array2));

            for (var i = 0; i < length; ++i)
            {
                if (array1[array1Index + i] != array2[array2Index + i])
                    return false;
            }
            return true;
        }
    }
}
