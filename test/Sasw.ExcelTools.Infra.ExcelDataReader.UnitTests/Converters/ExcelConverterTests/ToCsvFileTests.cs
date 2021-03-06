﻿namespace Sasw.ExcelTools.Infra.ExcelDataReader.UnitTests.Converters.ExcelConverterTests
{
    using ExcelDataReader.Converters;
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestSupport;
    using Xunit;

    public static class ToCsvFileTests
    {
        public class Given_An_Excel_Stream_When_Converting_To_Csv_File
            : Given_WhenAsync_Then_Test
        {
            private ExcelConverter _sut;
            private Stream _sourceStream;
            private Exception _exception;
            private string _destinationFilePath;

            protected override void Given()
            {
                _sut = new ExcelConverter();
                var pathToFile = Path.Combine("TestSupport", "Samples", "test.xls");
                _sourceStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                _destinationFilePath = "result.csv";
            }

            protected override async Task WhenAsync()
            {
                try
                {
                    await _sut.ToCsvFile(_sourceStream, _destinationFilePath);
                }
                catch (Exception exception)
                {
                    _exception = exception;
                }
            }

            [Fact]
            public void Then_It_Should_Not_Throw_Any_Exception()
            {
                _exception.Should().BeNull();
            }

            [Fact]
            public void Then_It_Should_Have_Generated_A_Valid_File()
            {
                File.Exists(_destinationFilePath).Should().BeTrue();
            }

            [Fact]
            public void Then_It_Should_Not_Have_Readable_Source_Stream()
            {
                _sourceStream.CanRead.Should().BeFalse();
            }

            [Fact]
            public void Then_It_Should_Not_Have_Writable_Source_Stream()
            {
                _sourceStream.CanWrite.Should().BeFalse();
            }

            [Fact]
            public void Then_It_Should_Not_Have_Seekable_Source_Stream()
            {
                _sourceStream.CanSeek.Should().BeFalse();
            }
        }
    }
}