/* Copyright (c) Cloud Software Group, Inc.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 *   1) Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 *
 *   2) Redistributions in binary form must reproduce the above
 *      copyright notice, this list of conditions and the following
 *      disclaimer in the documentation and/or other materials
 *      provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
 * COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using Newtonsoft.Json;


namespace XenAPI
{
    [JsonConverter(typeof(vmss_typeConverter))]
    public enum vmss_type
    {
        /// <summary>
        /// The snapshot is a disk snapshot
        /// </summary>
        snapshot,
        /// <summary>
        /// The snapshot is a checkpoint
        /// </summary>
        checkpoint,
        /// <summary>
        /// Support for VSS has been removed.
        /// </summary>
        snapshot_with_quiesce,
        unknown
    }

    public static class vmss_type_helper
    {
        public static string ToString(vmss_type x)
        {
            return x.StringOf();
        }
    }

    public static partial class EnumExt
    {
        public static string StringOf(this vmss_type x)
        {
            switch (x)
            {
                case vmss_type.snapshot:
                    return "snapshot";
                case vmss_type.checkpoint:
                    return "checkpoint";
                case vmss_type.snapshot_with_quiesce:
                    return "snapshot_with_quiesce";
                default:
                    return "unknown";
            }
        }
    }

    internal class vmss_typeConverter : XenEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((vmss_type)value).StringOf());
        }
    }
}