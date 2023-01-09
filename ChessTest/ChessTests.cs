using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Chess.Tests
{
	[TestClass()]
	public class ChessTests
	{
		[TestMethod()]
		public void ClassicBoardPawnTest()
		{
			Form1 form1 = new Form1();
			form1.ClassicBoard();

			for (int i = 0; i < 8; i++)
			{
				int piece;
				if ((piece = form1.cells[1, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({1}, {i}), piece was {piece} and needs to be 6"); }
				if ((piece = form1.cells[6, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({6}, {i}), piece was {piece} and needs to be 6"); }
			}
		}

		[TestMethod()]
		public void ClassicBoardBacklineTest()
		{
			Form1 form1 = new Form1();
			form1.ClassicBoard();

			int[] classicBL = new int[8] { 5, 4, 3, 2, 1, 3, 4, 5 };

			for (int i = 0; i < 8; i++)
			{
				int piece;
				if ((piece = form1.cells[0, i].piece % 10) != classicBL[i]) { Assert.Fail($"Wrong piece in cell ({0}, {i}), piece was {piece} and needs to be {classicBL[i]}"); }
				if ((piece = form1.cells[1, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({1}, {i}), piece was {piece} and needs to be 6"); }

				for (int j = 2; j < 6; j++)
				{
					if ((piece = form1.cells[j, i].piece % 10) != 0) { Assert.Fail($"Wrong piece in cell ({j}, {i}), piece was {piece} and needs to be 0"); }
				}

				if ((piece = form1.cells[6, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({6}, {i}), piece was {piece} and needs to be 6"); }
				if ((piece = form1.cells[7, i].piece % 10) != classicBL[i]) { Assert.Fail($"Wrong piece in cell ({7}, {i}), piece was {piece} and needs to be {classicBL[i]}"); }
			}
		}

		[TestMethod()]
		public void ClassicBoardMiddleTest()
		{
			Form1 form1 = new Form1();
			form1.ClassicBoard();

			for (int i = 0; i < 8; i++)
			{
				int piece;
				for (int j = 2; j < 6; j++)
				{
					if ((piece = form1.cells[j, i].piece % 10) != 0) { Assert.Fail($"Wrong piece in cell ({j}, {i}), piece was {piece} and needs to be 0"); }
				}
			}
		}

		[TestMethod()]
		public void ClassicBoardColorTest()
		{
			Form1 form1 = new Form1();
			form1.ClassicBoard();

			for (int i = 0; i < 8; i++)
			{
				int color;
				if ((color = form1.cells[0, i].piece / 10) != 2) { Assert.Fail($"Wrong color in cell {0}, {i}, color was {color} and needs to be 2"); }
				if ((color = form1.cells[1, i].piece / 10) != 2) { Assert.Fail($"Wrong color in cell {1}, {i}, color was {color} and needs to be 2"); }
				if ((color = form1.cells[6, i].piece / 10) != 1) { Assert.Fail($"Wrong color in cell {6}, {i}, color was {color} and needs to be 1"); }
				if ((color = form1.cells[7, i].piece / 10) != 1) { Assert.Fail($"Wrong color in cell {7}, {i}, color was {color} and needs to be 1"); }
			}
		}

		[TestMethod()]
		public void NineSixtyBoardPawnTest()
		{
			Form1 form1 = new Form1();
			form1.NineSixtyBoard();

			for (int i = 0; i < 8; i++)
			{
				int piece;
				if ((piece = form1.cells[1, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({1}, {i}), piece was {piece} and needs to be 6"); }
				if ((piece = form1.cells[6, i].piece % 10) != 6) { Assert.Fail($"Wrong piece in cell ({6}, {i}), piece was {piece} and needs to be 6"); }
			}
		}

		[TestMethod()]
		public void NineSixtyBoardBackLineTest()
		{
			Form1 form1 = new Form1();
			form1.NineSixtyBoard();

			//Check all pieces are valid
			int rook0 = -1, rook1 = -1;
			int bishop0 = -1, bishop1 = -1;
			int knight0 = -1, knight1 = -1;
			int king = -1;
			int queen = -1;

			for (int i = 0; i < 8; i++)
			{
				if (form1.cells[0, i].piece % 10 != form1.cells[7, i].piece % 10)
				{
					Assert.Fail($"Board must be mirrored, cell {0}, {i} ({form1.cells[0, i].piece % 10}) doesn't match cell {7}, {i} ({form1.cells[7, i].piece % 10})");
				}

				switch (form1.cells[0, i].piece % 10)
				{
					case 0:
						Assert.Fail($"All cells must be filled on the back line, cell {0}, {i} was empty");
						break;
					case 1:
						if (king != -1) { Assert.Fail($"There must only be one king per side, king found on {0}, {king} and {0}, {i}"); }
						if (rook0 == -1) { Assert.Fail($"There must be a rook to the left of the king on {0}, {i}"); }
						if (rook1 == 1) { Assert.Fail($"There must be a rook to the right of the king on {0}, {i}"); }
						king = i;
						break;
					case 2:
						if (queen != -1) { Assert.Fail($"There must only be one queen per side, queen found on {0}, {queen} and {0}, {i}"); }
						queen = i;
						break;
					case 3:
						if (bishop0 != -1)
						{
							if (bishop1 != -1) { Assert.Fail($"There must be exactly two bishops, bishops found on {0}, {bishop0}, {0}, {bishop1}, and {0}, {i}"); }
							if (bishop0 % 2 == i % 2) { Assert.Fail($"Bishops must be on opposite colors"); }

							bishop1 = i;
						}
						else { bishop0 = i; }
						break;
					case 4:
						if (knight0 != -1)
						{
							if (knight1 != -1) { Assert.Fail($"There must be exactly two knights, knights found on {0}, {knight0}, {0}, {knight1}, and {0}, {i}"); }

							knight1 = i;
						}
						else { knight0 = i; }
						break;
					case 5:
						if (rook0 != -1)
						{
							if (rook1 != -1) { Assert.Fail($"There must be exactly two rooks, rooks found on {0}, {rook0}, {0}, {rook1}, and {0}, {i}"); }

							rook1 = i;
						}
						else { rook0 = i; }
						break;
				}
			}
		}

		[TestMethod()]
		public void NineSixtyBoardMiddleTest()
		{
			Form1 form1 = new Form1();
			form1.NineSixtyBoard();

			for (int i = 0; i < 8; i++)
			{
				int piece;
				for (int j = 2; j < 6; j++)
				{
					if ((piece = form1.cells[j, i].piece % 10) != 0) { Assert.Fail($"Wrong piece in cell ({j}, {i}), piece was {piece} and needs to be 0"); }
				}
			}
		}

		[TestMethod()]
		public void NineSixtyBoardColorTest()
		{
			Form1 form1 = new Form1();
			form1.NineSixtyBoard();

			for (int i = 0; i < 8; i++)
			{
				int color;
				if ((color = form1.cells[0, i].piece / 10) != 2) { Assert.Fail($"Wrong color in cell {0}, {i}, color was {color} and needs to be 2"); }
				if ((color = form1.cells[1, i].piece / 10) != 2) { Assert.Fail($"Wrong color in cell {1}, {i}, color was {color} and needs to be 2"); }
				if ((color = form1.cells[6, i].piece / 10) != 1) { Assert.Fail($"Wrong color in cell {6}, {i}, color was {color} and needs to be 1"); }
				if ((color = form1.cells[7, i].piece / 10) != 1) { Assert.Fail($"Wrong color in cell {7}, {i}, color was {color} and needs to be 1"); }
			}
		}
	}
}
