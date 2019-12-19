﻿using oledid.SyntaxImprovement.Generators.TsFromCs;
using System;
using System.Collections.Generic;
using Xunit;

namespace oledid.SyntaxImprovement.Tests.Generators.TsFromCs
{
	public class TsFromCsGeneratorTests
	{
		[Fact]
		public void It_can_generate_dtos()
		{
			const string expected = @"interface IPersonEntity {
	id: number;
	name?: string;
	isActive: boolean;
	uniqueId: string;
	createdOn: Date;
	deletedOn?: Date;
	favoriteTypes?: ITypesEntity;
	parent?: IPersonEntity;
	ignoredClass?: any;
}

interface ITypesEntity {
	int: number;
	nullableInt?: number;
	nullableBool?: boolean;
	long: number;
	nullableLong?: number;
	short: number;
	nullableShort?: number;
	string?: string;
	nullableGuid?: string;
	intArray: Array<number>;
	stringList: Array<string>;
	guidEnumerable: Array<string>;
}
";
			var actual = TsFromCsGenerator.GenerateTypescriptInterfaceFromCsharpClass(typeof(PersonEntity), typeof(TypesEntity), typeof(IgnoredClass));
			Assert.Equal(expected, actual);
		}

		public class PersonEntity
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public bool IsActive { get; set; }
			public Guid UniqueId { get; set; }
			public DateTime CreatedOn { get; set; }
			public DateTime? DeletedOn { get; set; }

			public TypesEntity FavoriteTypes { get; set; }
			public PersonEntity Parent { get; set; }
			public IgnoredClass IgnoredClass { get; set; }
		}

		public class TypesEntity
		{
			public int Int { get; set; }
			public int? NullableInt { get; set; }
			public bool? NullableBool { get; set; }
			public long Long { get; set; }
			public long? NullableLong { get; set; }
			public short Short { get; set; }
			public short? NullableShort { get; set; }
			public string String { get; set; }
			public Guid? NullableGuid { get; set; }
			public int[] intArray { get; set; }
			public List<string> stringList { get; set; }
			public IEnumerable<Guid> guidEnumerable { get; set; }

			[TsFromCsIgnore]
			public int IgnoredInt { get; set; }
		}

		[TsFromCsIgnore]
		public class IgnoredClass
		{
			public int Id { get; set; }
		}
	}
}
