using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Super_Mario_Land_3D_Savegame_Editor {
	public partial class SM3DL_SGE: Form {
		public SM3DL_SGE() {
			InitializeComponent();
		}

		public string savegame;
		public byte[] crc32_data;
		public byte[] world_unlock = {
			0xFF,
			0xFF,
			0xFF,
			0xFF
		};

		public string ByteArrayToString(byte[] byteArray) {
			var hex = new StringBuilder(byteArray.Length * 2);
			foreach(var b in byteArray)
			hex.AppendFormat("{0:X2}", b);
			return hex.ToString();
		}
		public static byte[] BLKDTH_StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length).Where(x = >x % 2 == 0).Select(x = >Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();

		}

		private void BLKDTH_get_openfile() {
			OpenFileDialog openFD = new OpenFileDialog();
			if (openFD.ShowDialog() == DialogResult.OK) {
				savegame = openFD.FileName;
			}
		}
		private void BLKDTH_get_data() {
			{
				FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
				BinaryReader savegame_br = new BinaryReader(savegame_fs);
				long length = savegame_fs.Length;

				#region Save 1 main
				// lives save 1
				savegame_br.BaseStream.Position = 0x34DF;
				byte[] lives1 = savegame_br.ReadBytes(2);
				int f1l = BitConverter.ToInt16(lives1, 0);
				box_file1_lives.Text = (f1l.ToString());
				// star coins save 1
				savegame_br.BaseStream.Position = 0x34E1;
				byte[] scoins1 = savegame_br.ReadBytes(2);
				int f1c = BitConverter.ToInt16(scoins1, 0);
				box_file1_coins.Text = (f1c.ToString());
				#endregion

				#region Save 1 status item
				// start as p1
				savegame_br.BaseStream.Position = 0x2B7A;
				byte[] p1_start_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p1_start_byte) == "00") {
					p1_start_as.SelectedIndex = 0;
				} else if (ByteArrayToString(p1_start_byte) == "01") {
					p1_start_as.SelectedIndex = 1;
				} else if (ByteArrayToString(p1_start_byte) == "02") {
					p1_start_as.SelectedIndex = 2;
				} else if (ByteArrayToString(p1_start_byte) == "03") {
					p1_start_as.SelectedIndex = 3;
				} else if (ByteArrayToString(p1_start_byte) == "04") {
					p1_start_as.SelectedIndex = 4;
				} else if (ByteArrayToString(p1_start_byte) == "05") {
					p1_start_as.SelectedIndex = 5;
				}
				// item p1
				savegame_br.BaseStream.Position = 0x2B7C;
				byte[] p1_item_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p1_item_byte) == "00") {
					p1_itembox.SelectedIndex = 0;
				} else if (ByteArrayToString(p1_item_byte) == "01") {
					p1_itembox.SelectedIndex = 1;
				} else if (ByteArrayToString(p1_item_byte) == "02") {
					p1_itembox.SelectedIndex = 2;
				} else if (ByteArrayToString(p1_item_byte) == "03") {
					p1_itembox.SelectedIndex = 3;
				} else if (ByteArrayToString(p1_item_byte) == "04") {
					p1_itembox.SelectedIndex = 4;
				} else if (ByteArrayToString(p1_item_byte) == "05") {
					p1_itembox.SelectedIndex = 5;
				}
				#endregion

				#region Save 2 main
				// lives save 2
				savegame_br.BaseStream.Position = 0x3E62;
				byte[] lives2 = savegame_br.ReadBytes(2);
				int f2l = BitConverter.ToInt16(lives2, 0);
				box_file2_lives.Text = (f2l.ToString());
				// star coins save 2
				savegame_br.BaseStream.Position = 0x3E64;
				byte[] scoins2 = savegame_br.ReadBytes(2);
				int f2c = BitConverter.ToInt16(scoins2, 0);
				box_file2_coins.Text = (f2c.ToString());
				#endregion

				#region Save 2 status item
				// start as p2
				savegame_br.BaseStream.Position = 0x34FD;
				byte[] p2_start_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p2_start_byte) == "00") {
					p2_start_as.SelectedIndex = 0;
				} else if (ByteArrayToString(p2_start_byte) == "01") {
					p2_start_as.SelectedIndex = 1;
				} else if (ByteArrayToString(p2_start_byte) == "02") {
					p2_start_as.SelectedIndex = 2;
				} else if (ByteArrayToString(p2_start_byte) == "03") {
					p2_start_as.SelectedIndex = 3;
				} else if (ByteArrayToString(p2_start_byte) == "04") {
					p2_start_as.SelectedIndex = 4;
				} else if (ByteArrayToString(p2_start_byte) == "05") {
					p2_start_as.SelectedIndex = 5;
				}
				// item p2
				savegame_br.BaseStream.Position = 0x34FF;
				byte[] p2_item_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p2_item_byte) == "00") {
					p2_itembox.SelectedIndex = 0;
				} else if (ByteArrayToString(p2_item_byte) == "01") {
					p2_itembox.SelectedIndex = 1;
				} else if (ByteArrayToString(p2_item_byte) == "02") {
					p2_itembox.SelectedIndex = 2;
				} else if (ByteArrayToString(p2_item_byte) == "03") {
					p2_itembox.SelectedIndex = 3;
				} else if (ByteArrayToString(p2_item_byte) == "04") {
					p2_itembox.SelectedIndex = 4;
				} else if (ByteArrayToString(p2_item_byte) == "05") {
					p2_itembox.SelectedIndex = 5;
				}
				#endregion

				#region Save 3 main
				// lives save 3
				savegame_br.BaseStream.Position = 0x47E5;
				byte[] lives3 = savegame_br.ReadBytes(2);
				int f3l = BitConverter.ToInt16(lives3, 0);
				box_file3_lives.Text = (f3l.ToString());
				// star coins save 3
				savegame_br.BaseStream.Position = 0x47E7;
				byte[] scoins3 = savegame_br.ReadBytes(2);
				int f3c = BitConverter.ToInt16(scoins3, 0);
				box_file3_coins.Text = (f3c.ToString());
				#endregion

				#region Save 3 status item
				// start as p3
				savegame_br.BaseStream.Position = 0x3E80;
				byte[] p3_start_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p3_start_byte) == "00") {
					p3_start_as.SelectedIndex = 0;
				} else if (ByteArrayToString(p3_start_byte) == "01") {
					p3_start_as.SelectedIndex = 1;
				} else if (ByteArrayToString(p3_start_byte) == "02") {
					p3_start_as.SelectedIndex = 2;
				} else if (ByteArrayToString(p3_start_byte) == "03") {
					p3_start_as.SelectedIndex = 3;
				} else if (ByteArrayToString(p3_start_byte) == "04") {
					p3_start_as.SelectedIndex = 4;
				} else if (ByteArrayToString(p3_start_byte) == "05") {
					p3_start_as.SelectedIndex = 5;
				}
				// item p3
				savegame_br.BaseStream.Position = 0x3E82;
				byte[] p3_item_byte = savegame_br.ReadBytes(1);
				if (ByteArrayToString(p3_item_byte) == "00") {
					p3_itembox.SelectedIndex = 0;
				} else if (ByteArrayToString(p3_item_byte) == "01") {
					p3_itembox.SelectedIndex = 1;
				} else if (ByteArrayToString(p3_item_byte) == "02") {
					p3_itembox.SelectedIndex = 2;
				} else if (ByteArrayToString(p3_item_byte) == "03") {
					p3_itembox.SelectedIndex = 3;
				} else if (ByteArrayToString(p3_item_byte) == "04") {
					p3_itembox.SelectedIndex = 4;
				} else if (ByteArrayToString(p3_item_byte) == "05") {
					p3_itembox.SelectedIndex = 5;
				}
				#endregion

				savegame_br.Close();
			}
		}
		private void BLKDTH_set_data() {
			FileStream update_save_open = null;
			BinaryWriter update_save_write = null;
			update_save_open = new FileStream(savegame, FileMode.OpenOrCreate);
			update_save_write = new BinaryWriter(update_save_open);

			#region Save main
			byte[] f1_lives = BLKDTH_StringToByteArray(int.Parse(box_file1_lives.Text).ToString("X8"));
			Array.Reverse(f1_lives);
			update_save_open.Position = Convert.ToInt64("34DF", 16);
			update_save_write.Write(f1_lives);

			byte[] f1_coins = BLKDTH_StringToByteArray(int.Parse(box_file1_coins.Text).ToString("X8"));
			Array.Reverse(f1_coins);
			update_save_open.Position = Convert.ToInt64("34E1", 16);
			update_save_write.Write(f1_coins);
			#endregion

			#region Save 1 status item
			// p1 start as
			update_save_open.Position = 0x2B7A;

			if (p1_start_as.SelectedIndex == 0) {
				byte[] x1s = {
					0x00
				};
				update_save_write.Write(x1s, 0, 1);
			} else if (p1_start_as.SelectedIndex == 1) {
				byte[] x1s = {
					0x01
				};
				update_save_write.Write(x1s, 0, 1);
			} else if (p1_start_as.SelectedIndex == 2) {
				byte[] x1s = {
					0x02
				};
				update_save_write.Write(x1s, 0, 1);
			} else if (p1_start_as.SelectedIndex == 3) {
				byte[] x1s = {
					0x03
				};
				update_save_write.Write(x1s, 0, 1);
			} else if (p1_start_as.SelectedIndex == 4) {
				byte[] x1s = {
					0x04
				};
				update_save_write.Write(x1s, 0, 1);
			} else if (p1_start_as.SelectedIndex == 5) {
				byte[] x1s = {
					0x05
				};
				update_save_write.Write(x1s, 0, 1);
			}
			// p1 itembox
			update_save_open.Position = 0x2B7C;

			if (p1_itembox.SelectedIndex == 0) {
				byte[] x1i = {
					0x00
				};
				update_save_write.Write(x1i, 0, 1);
			} else if (p1_itembox.SelectedIndex == 1) {
				byte[] x1i = {
					0x01
				};
				update_save_write.Write(x1i, 0, 1);
			} else if (p1_itembox.SelectedIndex == 2) {
				byte[] x1i = {
					0x02
				};
				update_save_write.Write(x1i, 0, 1);
			} else if (p1_itembox.SelectedIndex == 3) {
				byte[] x1i = {
					0x03
				};
				update_save_write.Write(x1i, 0, 1);
			} else if (p1_itembox.SelectedIndex == 4) {
				byte[] x1i = {
					0x04
				};
				update_save_write.Write(x1i, 0, 1);
			} else if (p1_itembox.SelectedIndex == 5) {
				byte[] x1i = {
					0x05
				};
				update_save_write.Write(x1i, 0, 1);
			}
			#endregion

			#region Save 1 unlock worlds
			if (unlock_worlds_s1.Checked == true) {
				update_save_open.Position = 0x2B8C;
				update_save_write.Write(world_unlock);
			}
			#endregion

			#region Save 2 main
			byte[] f2_lives = BLKDTH_StringToByteArray(int.Parse(box_file2_lives.Text).ToString("X8"));
			Array.Reverse(f2_lives);
			update_save_open.Position = Convert.ToInt64("3E62", 16);
			update_save_write.Write(f2_lives);

			byte[] f2_coins = BLKDTH_StringToByteArray(int.Parse(box_file2_coins.Text).ToString("X8"));
			Array.Reverse(f2_coins);
			update_save_open.Position = Convert.ToInt64("3E64", 16);
			update_save_write.Write(f2_coins);
			#endregion
			
			#region Save 2 status item
			// p2 start as
			update_save_open.Position = 0x34FD;

			if (p2_start_as.SelectedIndex == 0) {
				byte[] x2s = {
					0x00
				};
				update_save_write.Write(x2s, 0, 1);
			} else if (p2_start_as.SelectedIndex == 1) {
				byte[] x2s = {
					0x01
				};
				update_save_write.Write(x2s, 0, 1);
			} else if (p2_start_as.SelectedIndex == 2) {
				byte[] x2s = {
					0x02
				};
				update_save_write.Write(x2s, 0, 1);
			} else if (p2_start_as.SelectedIndex == 3) {
				byte[] x2s = {
					0x03
				};
				update_save_write.Write(x2s, 0, 1);
			} else if (p2_start_as.SelectedIndex == 4) {
				byte[] x2s = {
					0x04
				};
				update_save_write.Write(x2s, 0, 1);
			} else if (p2_start_as.SelectedIndex == 5) {
				byte[] x2s = {
					0x05
				};
				update_save_write.Write(x2s, 0, 1);
			}
			// p2 itembox
			update_save_open.Position = 0x34FF;

			if (p2_itembox.SelectedIndex == 0) {
				byte[] x2i = {
					0x00
				};
				update_save_write.Write(x2i, 0, 1);
			} else if (p2_itembox.SelectedIndex == 1) {
				byte[] x2i = {
					0x01
				};
				update_save_write.Write(x2i, 0, 1);
			} else if (p2_itembox.SelectedIndex == 2) {
				byte[] x2i = {
					0x02
				};
				update_save_write.Write(x2i, 0, 1);
			} else if (p2_itembox.SelectedIndex == 3) {
				byte[] x2i = {
					0x03
				};
				update_save_write.Write(x2i, 0, 1);
			} else if (p2_itembox.SelectedIndex == 4) {
				byte[] x2i = {
					0x04
				};
				update_save_write.Write(x2i, 0, 1);
			} else if (p2_itembox.SelectedIndex == 5) {
				byte[] x2i = {
					0x05
				};
				update_save_write.Write(x2i, 0, 1);
			}
			#endregion

			#region Save 2 unlock worlds
			if (unlock_worlds_s2.Checked == true) {
				update_save_open.Position = 0x350F;
				update_save_write.Write(world_unlock);
			}
			#endregion

			#region Save 3 main
			byte[] f3_lives = BLKDTH_StringToByteArray(int.Parse(box_file3_lives.Text).ToString("X8"));
			Array.Reverse(f3_lives);
			update_save_open.Position = Convert.ToInt64("47E5", 16);
			update_save_write.Write(f3_lives);

			byte[] f3_coins = BLKDTH_StringToByteArray(int.Parse(box_file3_coins.Text).ToString("X8"));
			Array.Reverse(f3_coins);
			update_save_open.Position = Convert.ToInt64("47E7", 16);
			update_save_write.Write(f3_coins);
			#endregion

			#region Save 3 status item
			// p3 start as
			update_save_open.Position = 0x3E80;

			if (p3_start_as.SelectedIndex == 0) {
				byte[] x3s = {
					0x00
				};
				update_save_write.Write(x3s, 0, 1);
			} else if (p3_start_as.SelectedIndex == 1) {
				byte[] x3s = {
					0x01
				};
				update_save_write.Write(x3s, 0, 1);
			} else if (p3_start_as.SelectedIndex == 2) {
				byte[] x3s = {
					0x02
				};
				update_save_write.Write(x3s, 0, 1);
			} else if (p3_start_as.SelectedIndex == 3) {
				byte[] x3s = {
					0x03
				};
				update_save_write.Write(x3s, 0, 1);
			} else if (p3_start_as.SelectedIndex == 4) {
				byte[] x3s = {
					0x04
				};
				update_save_write.Write(x3s, 0, 1);
			} else if (p3_start_as.SelectedIndex == 5) {
				byte[] x3s = {
					0x05
				};
				update_save_write.Write(x3s, 0, 1);
			}
			// p3 itembox
			update_save_open.Position = 0x3E82;

			if (p3_itembox.SelectedIndex == 0) {
				byte[] x3i = {
					0x00
				};
				update_save_write.Write(x3i, 0, 1);
			} else if (p3_itembox.SelectedIndex == 1) {
				byte[] x3i = {
					0x01
				};
				update_save_write.Write(x3i, 0, 1);
			} else if (p3_itembox.SelectedIndex == 2) {
				byte[] x3i = {
					0x02
				};
				update_save_write.Write(x3i, 0, 1);
			} else if (p3_itembox.SelectedIndex == 3) {
				byte[] x3i = {
					0x03
				};
				update_save_write.Write(x3i, 0, 1);
			} else if (p3_itembox.SelectedIndex == 4) {
				byte[] x3i = {
					0x04
				};
				update_save_write.Write(x3i, 0, 1);
			} else if (p3_itembox.SelectedIndex == 5) {
				byte[] x3i = {
					0x05
				};
				update_save_write.Write(x3i, 0, 1);
			}
			#endregion

			#region Save 3 unlock worlds
			if (unlock_worlds_s3.Checked == true) {
				update_save_open.Position = 0x3E92;
				update_save_write.Write(world_unlock);
			}
			#endregion

			update_save_open.Close();
		}
		private void BLKDTH_crc32fix() {
			FileStream savegame_fs = new FileStream(savegame, FileMode.Open);
			BinaryReader savegame_br = new BinaryReader(savegame_fs);
			BinaryWriter update_save_crc32 = null;

			savegame_br.BaseStream.Position = 0x04;
			byte[] crc32_data = savegame_br.ReadBytes(Convert.ToInt32(savegame_fs.Length));
			Crc32 crc32 = new Crc32();
			String hash = String.Empty;
			foreach(byte b in crc32.ComputeHash(crc32_data)) hash += b.ToString("x2"); //.ToLower();
			byte[] crc32_data_fixed = BLKDTH_StringToByteArray(hash);
			Array.Reverse(crc32_data_fixed);
			int f2c = BitConverter.ToInt32(crc32_data_fixed, 0);

			update_save_crc32 = new BinaryWriter(savegame_fs);
			savegame_fs.Position = Convert.ToInt64("00", 16);
			update_save_crc32.Write(crc32_data_fixed);
			savegame_br.Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			BLKDTH_set_data();
			BLKDTH_crc32fix();
			MessageBox.Show("Data saved");
		}
		private void button1_Click(object sender, EventArgs e) {
			BLKDTH_get_openfile();
			if (string.IsNullOrEmpty(savegame)) {
				MessageBox.Show("no savegame selected");
			} else {
				BLKDTH_get_data();
			}
		}

		#region WIP Option
		private void unlock_worlds_s1_CheckedChanged(object sender, EventArgs e) {
			if (unlock_worlds_s1.Checked == true) {
				if (MessageBox.Show("This is a WIP Option." + Environment.NewLine + "Make sure you have a backup of your savegame", "unlock all Worlds", MessageBoxButtons.OKCancel) == DialogResult.OK) {
					unlock_worlds_s1.Checked = true;
				} else {
					unlock_worlds_s1.Checked = false;
				}
			}
		}
		private void unlock_worlds_s2_CheckedChanged(object sender, EventArgs e) {
			if (unlock_worlds_s2.Checked == true) {
				if (MessageBox.Show("This is a WIP Option." + Environment.NewLine + "Make sure you have a backup of your savegame", "unlock all Worlds", MessageBoxButtons.OKCancel) == DialogResult.OK) {
					unlock_worlds_s2.Checked = true;
				} else {
					unlock_worlds_s2.Checked = false;
				}
			}
		}
		private void unlock_worlds_s3_CheckedChanged(object sender, EventArgs e) {
			if (unlock_worlds_s3.Checked == true) {
				if (MessageBox.Show("This is a WIP Option." + Environment.NewLine + "Make sure you have a backup of your savegame", "unlock all Worlds", MessageBoxButtons.OKCancel) == DialogResult.OK) {
					unlock_worlds_s3.Checked = true;
				} else {
					unlock_worlds_s3.Checked = false;
				}
			}
		}
		#endregion
	}
}
