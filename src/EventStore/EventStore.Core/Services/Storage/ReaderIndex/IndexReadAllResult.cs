// Copyright (c) 2012, Event Store LLP
// All rights reserved.
//  
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//  
// Redistributions of source code must retain the above copyright notice,
// this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer in the
// documentation and/or other materials provided with the distribution.
// Neither the name of the Event Store LLP nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//  
using System.Collections.Generic;
using System.Linq;
using EventStore.Common.Utils;
using EventStore.Core.Data;

namespace EventStore.Core.Services.Storage.ReaderIndex
{
    public struct IndexReadAllResult
    {
        public readonly List<CommitEventRecord> Records;
        public readonly StreamMetadata Metadata;
        public readonly int MaxCount;
        public readonly TFPos CurrentPos;
        public readonly TFPos NextPos;
        public readonly TFPos PrevPos;
        public readonly long TfEofPosition;

        public IndexReadAllResult(List<CommitEventRecord> records, 
                                  StreamMetadata metadata,
                                  int maxCount, 
                                  TFPos currentPos, 
                                  TFPos nextPos, 
                                  TFPos prevPos, 
                                  long tfEofPosition)
        {
            Ensure.NotNull(records, "records");

            Records = records;
            Metadata = metadata;
            MaxCount = maxCount;
            CurrentPos = currentPos;
            NextPos = nextPos;
            PrevPos = prevPos;
            TfEofPosition = tfEofPosition;
        }

        public override string ToString()
        {
            return string.Format("NextPos: {0}, PrevPos: {1}, Records: {2}, Metadata: {3}",
                                 NextPos,
                                 PrevPos,
                                 string.Join("\n", Records.Select(x => x.ToString())),
                                 Metadata);
        }
    }
}