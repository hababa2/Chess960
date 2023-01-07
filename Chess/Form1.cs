using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public struct Cell
	{
		public Cell(int unused)
		{
			piece = 0;
			justMoved = false;
			starting = true;
			button = null;
		}

		public int piece;
		public bool justMoved;
		public bool starting;
		public Button button;
	}

	public partial class Form1 : Form
	{
		public Image chessSprites;
		public Cell[,] cells;

		public int currPlayer;

		public Button prevButton;

		public bool isMoving = false;

		private Random rng = new Random();
		private int[] classicBL = new int[8] { 5, 4, 3, 2, 1, 3, 4, 5 };
		private int[] nineSixtyBL = new int[8];

		public Form1()
		{
			InitializeComponent();

			chessSprites = new Bitmap("C:\\Development\\Existing\\ChessGame\\Chess\\Sprites\\chess.png");

			//button1.BackgroundImage = part;

			BlankBoard();
		}

		public void BlankBoard()
		{
			cells = new Cell[8, 8];

			CreateMap();
		}

		public void ClassicBoard()
		{
			cells = new Cell[8, 8] {
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) }};

			for (int i = 0; i < 8; i++)
			{
				cells[0, i].piece = classicBL[i] + 20;
				cells[1, i].piece = 26;
				cells[6, i].piece = 16;
				cells[7, i].piece = classicBL[i] + 10;
			}

			currPlayer = 1;
			CreateMap();
		}

		public void NineSixtyBoard()
		{
			cells = new Cell[8, 8] {
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) },
				{ new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0), new Cell(0) }};

			List<int> positions = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
			int king = rng.Next(1, 7);
			nineSixtyBL[king] = 1;
			positions.Remove(king);

			int rook = rng.Next(0, king);
			nineSixtyBL[rook] = 5;
			positions.Remove(rook);

			rook = rng.Next(king + 1, 8);
			nineSixtyBL[rook] = 5;
			positions.Remove(rook);

			int bishop = positions[rng.Next(positions.Count)];
			int color = bishop % 2;
			nineSixtyBL[bishop] = 3;
			positions.Remove(bishop);

			while ((bishop = positions[rng.Next(positions.Count)]) % 2 == color);
			nineSixtyBL[bishop] = 3;
			positions.Remove(bishop);

			int piece = positions[rng.Next(positions.Count)];
			nineSixtyBL[piece] = 2;
			positions.Remove(piece);

			piece = positions[rng.Next(positions.Count)];
			nineSixtyBL[piece] = 4;
			positions.Remove(piece);

			piece = positions[0];
			nineSixtyBL[piece] = 4;

			for (int i = 0; i < 8; i++)
			{
				cells[0, i].piece = nineSixtyBL[i] + 20;
				cells[1, i].piece = 26;
				cells[6, i].piece = 16;
				cells[7, i].piece = nineSixtyBL[i] + 10;
			}

			currPlayer = 1;
			CreateMap();
		}

		public void CreateMap()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Button butt = new Button();
					butt.Size = new Size(50, 50);
					butt.Location = new Point(j * 50, i * 50);

					switch (cells[i, j].piece / 10)
					{
						case 1:
							Image part = new Bitmap(50, 50);
							Graphics g = Graphics.FromImage(part);
							g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (cells[i, j].piece % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
							butt.BackgroundImage = part;
							break;
						case 2:
							Image part1 = new Bitmap(50, 50);
							Graphics g1 = Graphics.FromImage(part1);
							g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (cells[i, j].piece % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
							butt.BackgroundImage = part1;
							break;
					}
					butt.BackColor = Color.White;
					//butt.BackColor = Color.BurlyWood;
					//butt.BackColor = Color.BlanchedAlmond;
					butt.Click += new EventHandler(OnFigurePress);
					Controls.Add(butt);

					cells[i, j].button = butt;
				}
			}
		}

		public void OnFigurePress(object sender, EventArgs e)
		{
			if (prevButton != null) { prevButton.BackColor = Color.White; }

			Button pressedButton = sender as Button;

			int x = pressedButton.Location.X / 50;
			int y = pressedButton.Location.Y / 50;

			//pressedButton.Enabled = false;

			if (cells[y, x].piece / 10 == currPlayer)
			{
				CloseSteps();
				pressedButton.BackColor = Color.Red;
				DeactivateAllButtons();
				pressedButton.Enabled = true;
				ShowSteps(y, x, cells[y, x].piece);

				if (isMoving)
				{
					CloseSteps();
					pressedButton.BackColor = Color.White;
					ActivateAllButtons();
					isMoving = false;
				}
				else { isMoving = true; }
			}
			else
			{
				if (isMoving)
				{
					cells[y, x].starting = false;
					int prevX = prevButton.Location.X / 50;
					int prevY = prevButton.Location.Y / 50;
					int temp = cells[y, x].piece;
					cells[y, x].piece = cells[prevY, prevX].piece;
					cells[prevY, prevX].piece = temp;
					pressedButton.BackgroundImage = prevButton.BackgroundImage;
					prevButton.BackgroundImage = null;
					isMoving = false;
					CloseSteps();
					ActivateAllButtons();
					SwitchPlayer();
				}
			}

			prevButton = pressedButton;
		}

		public void ShowSteps(int IcurrFigure, int JcurrFigure, int currFigure)
		{
			int dir = currPlayer == 2 ? 1 : -1;
			switch (currFigure % 10)
			{
				case 6:
					if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure))
					{
						if (cells[IcurrFigure + 1 * dir, JcurrFigure].piece == 0)
						{
							cells[IcurrFigure + 1 * dir, JcurrFigure].button.BackColor = Color.Yellow;
							cells[IcurrFigure + 1 * dir, JcurrFigure].button.Enabled = true;
						}
					}

					if (InsideBorder(IcurrFigure + 2 * dir, JcurrFigure))
					{
						if (cells[IcurrFigure + 1 * dir, JcurrFigure].piece == 0 && cells[IcurrFigure + 2 * dir, JcurrFigure].piece == 0 && cells[IcurrFigure, JcurrFigure].starting)
						{
							cells[IcurrFigure + 2 * dir, JcurrFigure].button.BackColor = Color.Yellow;
							cells[IcurrFigure + 2 * dir, JcurrFigure].button.Enabled = true;
						}
					}

					if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure + 1))
					{
						if (cells[IcurrFigure + 1 * dir, JcurrFigure + 1].piece != 0 && cells[IcurrFigure + 1 * dir, JcurrFigure + 1].piece / 10 != currPlayer)
						{
							cells[IcurrFigure + 1 * dir, JcurrFigure + 1].button.BackColor = Color.Yellow;
							cells[IcurrFigure + 1 * dir, JcurrFigure + 1].button.Enabled = true;
						}
					}

					if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure - 1))
					{
						if (cells[IcurrFigure + 1 * dir, JcurrFigure - 1].piece != 0 && cells[IcurrFigure + 1 * dir, JcurrFigure - 1].piece / 10 != currPlayer)
						{
							cells[IcurrFigure + 1 * dir, JcurrFigure - 1].button.BackColor = Color.Yellow;
							cells[IcurrFigure + 1 * dir, JcurrFigure - 1].button.Enabled = true;
						}
					}
					break;
				case 5:
					ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
					break;
				case 3:
					ShowDiagonal(IcurrFigure, JcurrFigure);
					break;
				case 2:
					ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
					ShowDiagonal(IcurrFigure, JcurrFigure);
					break;
				case 1:
					ShowVerticalHorizontal(IcurrFigure, JcurrFigure, true);
					ShowDiagonal(IcurrFigure, JcurrFigure, true);
					break;
				case 4:
					ShowHorseSteps(IcurrFigure, JcurrFigure);
					break;
			}
		}

		public void ShowHorseSteps(int IcurrFigure, int JcurrFigure)
		{
			if (InsideBorder(IcurrFigure - 2, JcurrFigure + 1))
			{
				DeterminePath(IcurrFigure - 2, JcurrFigure + 1);
			}
			if (InsideBorder(IcurrFigure - 2, JcurrFigure - 1))
			{
				DeterminePath(IcurrFigure - 2, JcurrFigure - 1);
			}
			if (InsideBorder(IcurrFigure + 2, JcurrFigure + 1))
			{
				DeterminePath(IcurrFigure + 2, JcurrFigure + 1);
			}
			if (InsideBorder(IcurrFigure + 2, JcurrFigure - 1))
			{
				DeterminePath(IcurrFigure + 2, JcurrFigure - 1);
			}
			if (InsideBorder(IcurrFigure - 1, JcurrFigure + 2))
			{
				DeterminePath(IcurrFigure - 1, JcurrFigure + 2);
			}
			if (InsideBorder(IcurrFigure + 1, JcurrFigure + 2))
			{
				DeterminePath(IcurrFigure + 1, JcurrFigure + 2);
			}
			if (InsideBorder(IcurrFigure - 1, JcurrFigure - 2))
			{
				DeterminePath(IcurrFigure - 1, JcurrFigure - 2);
			}
			if (InsideBorder(IcurrFigure + 1, JcurrFigure - 2))
			{
				DeterminePath(IcurrFigure + 1, JcurrFigure - 2);
			}
		}

		public void DeactivateAllButtons()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					cells[i, j].button.Enabled = false;
				}
			}
		}

		public void ActivateAllButtons()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					cells[i, j].button.Enabled = true;
				}
			}
		}

		public void ShowDiagonal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
		{
			int j = JcurrFigure + 1;
			for (int i = IcurrFigure - 1; i >= 0; i--)
			{
				if (InsideBorder(i, j))
				{
					if (!DeterminePath(i, j))
						break;
				}
				if (j < 7)
					j++;
				else break;

				if (isOneStep)
					break;
			}

			j = JcurrFigure - 1;
			for (int i = IcurrFigure - 1; i >= 0; i--)
			{
				if (InsideBorder(i, j))
				{
					if (!DeterminePath(i, j))
						break;
				}
				if (j > 0)
					j--;
				else break;

				if (isOneStep)
					break;
			}

			j = JcurrFigure - 1;
			for (int i = IcurrFigure + 1; i < 8; i++)
			{
				if (InsideBorder(i, j))
				{
					if (!DeterminePath(i, j))
						break;
				}
				if (j > 0)
					j--;
				else break;

				if (isOneStep)
					break;
			}

			j = JcurrFigure + 1;
			for (int i = IcurrFigure + 1; i < 8; i++)
			{
				if (InsideBorder(i, j))
				{
					if (!DeterminePath(i, j))
						break;
				}
				if (j < 7)
					j++;
				else break;

				if (isOneStep)
					break;
			}
		}

		public void ShowVerticalHorizontal(int IcurrFigure, int JcurrFigure, bool isOneStep = false)
		{
			for (int i = IcurrFigure + 1; i < 8; i++)
			{
				if (InsideBorder(i, JcurrFigure))
				{
					if (!DeterminePath(i, JcurrFigure))
						break;
				}
				if (isOneStep)
					break;
			}
			for (int i = IcurrFigure - 1; i >= 0; i--)
			{
				if (InsideBorder(i, JcurrFigure))
				{
					if (!DeterminePath(i, JcurrFigure))
						break;
				}
				if (isOneStep)
					break;
			}
			for (int j = JcurrFigure + 1; j < 8; j++)
			{
				if (InsideBorder(IcurrFigure, j))
				{
					if (!DeterminePath(IcurrFigure, j))
						break;
				}
				if (isOneStep)
					break;
			}
			for (int j = JcurrFigure - 1; j >= 0; j--)
			{
				if (InsideBorder(IcurrFigure, j))
				{
					if (!DeterminePath(IcurrFigure, j))
						break;
				}
				if (isOneStep)
					break;
			}
		}

		public bool DeterminePath(int IcurrFigure, int j)
		{
			if (cells[IcurrFigure, j].piece == 0)
			{
				cells[IcurrFigure, j].button.BackColor = Color.Yellow;
				cells[IcurrFigure, j].button.Enabled = true;
			}
			else
			{
				if (cells[IcurrFigure, j].piece != 0 && cells[IcurrFigure, j].piece / 10 != currPlayer)
				{
					cells[IcurrFigure, j].button.BackColor = Color.Yellow;
					cells[IcurrFigure, j].button.Enabled = true;
				}
				return false;
			}
			return true;
		}

		public bool InsideBorder(int ti, int tj)
		{
			return ti > -1 && ti < 8 && tj > -1 && tj < 8;
		}

		public void CloseSteps()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					cells[i, j].button.BackColor = Color.White;
				}
			}
		}

		public void SwitchPlayer()
		{
			if (currPlayer == 1) { currPlayer = 2; }
			else { currPlayer = 1; }
		}

		private void button1_Click(object sender, EventArgs e) //Classic
		{
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j < 8; j++)
				{
					Controls.Remove(cells[i, j].button);
				}
			}

			//Controls.Clear();
			ClassicBoard();
		}

		private void button2_Click(object sender, EventArgs e) //Chess960
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Controls.Remove(cells[i, j].button);
				}
			}

			//Controls.Clear();
			NineSixtyBoard();
		}
	}
}
