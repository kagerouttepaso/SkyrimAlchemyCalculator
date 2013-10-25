using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;

namespace SkyrimAlchemyCalculator {
	public partial class Form1 : Form {
		/// <summary>
		/// 錬金素材のデータ
		/// </summary>
		class AlchemyData {
			public string Name{get;set;}
			public string Weight { get; set; }
			public string Value { get; set; }
			public List<string> Effect { get; set; }
		}
		/// <summary>
		/// 錬金結果表のエレメント
		/// </summary>
		class AlcamyPattern {
			public List<string> Name;
			public List<string> Effect;
		}

		/// <summary>
		/// 素材リスト
		/// </summary>
		List<AlchemyData> Datas { get; set; }
		/// <summary>
		/// 効果リスト
		/// </summary>
		List<string> Effects { get; set; }
		/// <summary>
		/// 選択された効果
		/// </summary>
		List<string> SelectItems { get; set; }
		IEnumerable<AlchemyData> SelectDatas { get; set; }
		IEnumerable<string> SelectEffects { get; set; }

		/// <summary>
		/// 錬金テ―ブル
		/// </summary>
		List<AlcamyPattern> AlcamyTable { get; set; }


		public Form1() {
			InitializeComponent();

			//何も選択しない
			SelectItems = new List<string>();

			//データベース作成
			Datas = new List<AlchemyData>();
			File.OpenText("database.txt").ReadToEnd()
				.Replace("\r\n", "\n")
				.Split('\n').Where(x => x != "").ToList()
				.ForEach(s => {
					var x = s.Split('\t');
					Datas.Add(new AlchemyData {
						Name = x[0],
						Weight = x[1],
						Value = x[2],
						Effect = new List<string>() { x[3], x[4], x[5], x[6] }
					});
				});

			//効果一覧作成
			Effects = new List<string>();
			Datas.ForEach(data => {
				foreach(var eff in data.Effect) {
					if(!Effects.Any(x => x == eff)) {
						Effects.Add(eff);
					}
				}
			});
			Effects = Effects.OrderBy(x => x).ToList();

			//テーブル作成
			createAlcamyTable();

			SelectDatas = Datas.AsEnumerable();
			SelectEffects = Effects.AsEnumerable();

			displayItems();

			/*
			var list = AlcamyTable.Where(x => x.Effect.Count() >= 5);
			debugTextBox.Text = list.Count().ToString();
			using(var fp = File.CreateText("out.txt")) {
				list.ToList().ForEach(data => {
					fp.WriteLine(string.Join("\t", data.Name) + "\t\t" + string.Join("\t", data.Effect));
				});
			}
			*/
		}

		private void button1_Click(object sender, EventArgs e) {
			updateItems();
		}

		/// <summary>
		/// 錬金レシピ計算
		/// </summary>
		void updateItems() {
			SelectItems = new List<string>();
			foreach(var item in checkedListBox.CheckedItems){
				var str = (string)item;
				SelectItems.Add(str);
			}

			var list = AlcamyTable.AsParallel()
				.Where(x => SelectItems.TrueForAll(item => x.Effect.Any(e => e == item)))
				.OrderBy(x => string.Concat(x)).ToList();

			var aa = new List<string>();
			list.ConvertAll(x => x.Effect).ForEach(x => aa.AddRange(x));
			SelectEffects = aa.Distinct().OrderBy(x => x).ToList();
			displayItems();
			

			//一覧に出力
			debugTextBox.Text = list.Count().ToString() + "\r\n";
			if(list.Count <= 100) {
				if(!Directory.Exists("Recipe"))
					Directory.CreateDirectory("Recipe");
				using(var fp = File.CreateText("Recipe\\" + string.Join(",", SelectItems) + ".txt")) {
					list.ForEach(data => {
						fp.WriteLine(string.Join("\t", data.Name) + "\t\t" + string.Join("\t", data.Effect));
						debugTextBox.Text += string.Join("\t", data.Name) + "\r\n\t" + string.Join("\t", data.Effect) + "\r\n\r\n";
					});
				}
			}

		}

		/// <summary>
		/// 組み合わせテーブル作成
		/// </summary>
		void createAlcamyTable() {
			var alcamyPatterns = new ConcurrentBag<AlcamyPattern>();
			AlcamyTable = new List<AlcamyPattern>();

			//総当り表を作る
			Datas.ForEach(data1 =>
				//data2がdata1より下にある
				Datas.SkipWhile(data2 => data2.Name != data1.Name).AsParallel()
				.ForAll(data2 => {
					if(data1.Name != data2.Name)
						//data3がdata2より下にある
						Datas.SkipWhile(data3 => data3.Name != data2.Name).AsParallel()
							.ForAll(data3 => {
								if(data2.Name != data3.Name) {
									//効果が発現するものをリストにする
									var effects = data1.Effect.Concat(data2.Effect).Concat(data3.Effect)
										//効果の集計
										.GroupBy(x => x, (key, list) => new { name = key, count = list.Count() })
										//効果が重なるものをいただく
										.Where(x => x.count > 1).Select(x => x.name);
									//効果が発現するパターンをテーブルに登録
									if(effects.Any())
										alcamyPatterns.Add(new AlcamyPattern() {
											Name = new List<string>() { data1.Name, data2.Name, data3.Name },
											Effect = new List<string>(effects)
										});
								}
							});
				}));
			AlcamyTable = alcamyPatterns.OrderBy(x => string.Concat(x.Name)).ToList();
		}

		void displayItems() {
			checkedListBox.Items.Clear();
			foreach(var str in SelectEffects) {
				checkedListBox.Items.Add(str, false);
			}
			SelectItems.ForEach(item => checkedListBox.SetItemChecked(
				checkedListBox.Items.IndexOf(item), true));

		}
	}
}
