using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yotsuba
{
    public partial class Form1 : Form
    {
        int clicks = -1;
        bool correct = true;
        bool correct1 = true;

        string[] textList = new string[]
        {
            //Clicks 0 - 4 (Yotsuba Sleepy)
            "あー、あさだ。", "。。。", "とーちゃん。。。？", "あさめし。。。","。。。", 

            //Clicks 5 - 6 (Yotsuba Neutral)
            "とーちゃん。。。？", "。。。", 

            //Clicks 7 - 8 (Yotsuba Surprised)
            "え？", "と、とーちゃん？", 

            //Clicks 9 - 10 (Tou-chan Neutral)
            "あ、もう起きたか、よつば？","すぐできるから、歯を磨け。", 

            //Click 11 (Tou-chan Sigh)
            "何だ、その顔。", 

            //Click 12 (Switch to Yotsuba)
            "ぺんぎん！ペンギンだ！", 

            //Clicks 13 - 14 (Switch to Tou-chan)
            "お前。。。まだ眠ってるか？", "昔からペンギンだったよ。", 

            //Click 15 (Switch to Yotsuba)
            "ち、ちがう！よつばととーちゃんはにんげん！", 

            //Click 16 - 17 (Switch to Tou-chan)

            "また変な事を言うな。", "ほら、見ろ。",

            //Click 18 (No Name)
            "かがみゲット！",

            //Click 19 (Background Switch & Switch to Tou-chan)

            "お前も鳥だ。",

            //Click 20 (Switch to Yotsuba)
            "う、うそー！",

            //Click 21 - 22 (Switch to Tou-chan)

            "嘘じゃね。", "早く歯を磨け。", 

            //Choice 2 - Click 23 - 24
            "そして、おいしい朝ご飯を食べてから、よつばちゃんがずっと鳥として住んでた。", "BAD END", 

            //Choice 1 - Click 25
            "よつば！どこ行くの？！",

            //Click 26 - 28 Scene Change (Yotsuba Tired)
            "ハーハー", "へん！ぜったいへん！", "どうする？！",

            //Click 29 (Switch to Fuuka)
            "あ、よつばちゃんか？一人で遊ぶ？",

            //Click 30 (Switch to Yotsuba)
            "しんてきだ！",

            //Click 31 (Switch to Fuuka)
            "えっ？　何ー？",

            //Click 32 - 33 (Switch to Yotsuba)
            "ひゃああ！", "よつばちょっぷ！",

            //Click 34 (Switch to Fuuka)
            "いた！",

            //Click 35 (No Name)
            "ふうかからにげた！",

            //Click 36 - 37 (Switch to Fuuka)
            "ま、待って！", "よつばちゃん、危ないよ！",

            //Click 38 (No Name)
            "十分後",

            //Click 39 - 44 Scene Change (Switch to Yotsuba)
            "ハー", "。。。", "わーーー", "どうしよー", "わーーー", "とうーちゃん！", 

            //Click 45 - 50
            "わ。。。", "。。。", "え？", "。。。", "どんぐりだ！", "ぼうしのどんぐりだ！",

            //Click 51 (No Name)

            "どんぐりゲット！", 

            //Click 52 - 53 (Switch to Yotsuba)
            "。。。", "あーいやされた。。。",

            //Click 54 (Switch to Juralumin)
            "よつば？よつばか？",

            //Click 55 - 57 (Switch to Yotsuba)
            "？！", "だれだ？！", "またてきか？！",

            //Click 58 (Switch to Juralumin)
            "しらないの？",

            //Click 59 (Switch to Yotsuba)
            "ぜんぜん！", 

            //Click 60 - 63 (Switch to Juralumin)
            "じゃ、ヒント！", "いぬにかまれてたね！", "で、あさぎにしゅじゅつしてもらった！", "だ～れか～な？",

            //Click 64 - 67 (Switch to Yotsuba)
            "。。。", "。。。", "ジュラルミン？！", "ほんもの？！", 

            //Click 68 (Switch to Juralumin)
            "ピンポン！",

            //Click 69 - 70 (Switch to Yotsuba)
            "うそ！", "ほんもののジュラルミンはテディベアだ！",

            //Click 71 - 72 (Switch to Juralumin)
            "じゃ、よつばはなんでヒヨコちゃん？", "ほんもののよつばはにんげんでしょう？",

            //Click 73 - 74 (Switch to Yotsuba)
            "そ、それは。。。", "。。。",

            //Click 75 - 76 (Switch to Juralumin)
            "このよにはみんなとりになちゃった。", "ジュラルミンはもうくまだったから、にんげんにならされた。", 

            //Click 77 (Switch to Yotsuba)
            "だ、だれに。。。？", 

            //Click 78 - 80 (Switch to Juralumin)
            "せかいいちのスーパーあくにん。", "よつばもしてる。。。", "かれのなまえはイヤンダマン。", 

            //Choice 3 - Click 81 (Switch to Juralumin)
            "えっ？", 

            //Click 82 (Switch to Yotsuba)
            "とーちゃんにかえる！", 

            //Click 83 (Switch to Juralumin)
            "まって！よつば！", 

            //Click 84 - 86 (No Name)
            "そして、とーちゃんに見つけられて、家に帰った。", "それから、よつばちゃんがずっと鳥として住んでた。", 
            "BAD END", 

            //Click 87 - 88(Switch to Juralumin)
            "うん。", "こんなすがた。",

            //Click 89 (No Name)
            "イヤンダマンのえゲット！",

            //Click 90 (Switch to Yotsuba)
            "。。。", 

            //Click 91 (Switch to Juralumin)
            "。。。", 

            //Click 92 (Switch to Yotsuba)
            "。。。", 

            //Click 93 (Switch to Juralumin)
            "。。。", 

            //Click 94 (Switch to Yotsuba)
            "ジュラルミンのえはへた。", 

            //Click 95 - 98 (Switch to Juralumin)
            "し、しかたがない！", "いままでくまだったのに。", "れんしゅうできなっかた。",
            "そ、それより！コンビにへいこう！", 

            //Click 99 (Switch to Yotsuba)
            "こんびに？",

            //Click 100 - 101 (Switch to Juralumin)
            "そう！イヤンダマンあそこにいるはず！", "じゃ、はやく！",

            //Click 102 - 104 (Scene change to Konbini)
            "ここだ！", "そろそろでてくる。", "よつば！", 

            //Click 105 (Switch to Yotsuba)
            "はい！たいちょう！", 

            //Click 106 - 107(Switch to Juralumin)
            "みんなにあいたいでしょう？", "なら、イヤンダマンがでてきたら、よつばキックでこうげきしよう！", 

            //Click 108 (Switch to Yotsuba)
            "ラジャ！", 

            //Click 109 (Switch to Juralumin)
            "でてきた！", 

            //Click 110 - 111 (Switch to Iyanda)
            "それじゃ。。。", "小岩井さんの家か。",

            //Click 112 - 113 (Switch to Juralumin)
            "よつば！", "いけー！", 

            //Click 114 - 115 (Switch to Yotsuba)
            "イヤンダマン！", "おまえをたおす！", 

            //Click 116 - 119 (Switch to Iyanda)
            "ん？", "。。。", "ゲッ！", "よつば？！", 

            //Click 120 - 121 (Switch to Yotsuba)
            "しねー！", "よつばキック！", 

            //Click 122 (Switch to Iyanda)
            "イタ！！", 

            //Click 123 (Switch to Juralumin)
            "よつばのかちだ！", 

            //Click 124 (Switch to Yotsuba)
            "なにかあらわれた！", 

            //Click 125 (Switch to Juralumin)
            "あのポータルにはいればほんとうのよにもどれる！", 

            //Click 126 (Switch to Yotsuba)
            "ほんとう？！", 

            //Click 127 - 128 (Switch to Juralumin)
            "ここからはさよならだ。", "よつばとしゃべれたからうれしい。", 

            //Click 129 (Switch to Yotsuba)
            "ジュラルミン。。。", 

            //Choice 5 - Click 130 (Switch to Juralumin)
            "えっ？かがみなんかいらないけど。。。", 

            //Choice 7 - Click 131 (Switch to Juralumin)
            "そんなにきらいの？！", 

            //Choice 6 - Click 132 (Switch to Juralumin)
            "えっ？", 

            //Click 133 - 134 (Switch to Yotsuba)
            "このどんぐりはほうせきになれる。", "えなにたずねて。", 

            //Click 135 - 137 (Switch to Juralumin)
            "うん、わかった！", "ありがとう、よつば！", "バイバイ！", 

            //Click 138 (Switch to Yotsuba)
            "バイバイ！", 

            //Click 139 - 141(Switch to Tou-chan)
            "。。。", "。。。。。", "。。。。。。。。。。", 

            //Click 142 - 146 (No Name)
            "よつば、お八つだ。。。", "あ、またテレビの前で寝ちゃった。", "ん？この絵は？", "。。。", "フッ。かわいい。"

        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yotsubaSprite.Parent = textBox;
            yotsubaSprite.Location = new Point(0, 0);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            clicks = -1;

            correct = true;
            correct1 = true;
            startButton.Visible = false;
            textBox.Visible = true;
            yotsubaSprite.Visible = true;
            yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSleepy;
            fuukaSprite.Image = Properties.Resources.Fuuka;
            touChanSprite.Image = Properties.Resources.TouChan;
            juraluminSprite.Image = Properties.Resources.Juralumin;
            iyandaSprite.Image = Properties.Resources.Iyandaman;
            nameLabel.Visible = true;
            nameLabel.Text = "よつば";
            nameLabel.ForeColor = System.Drawing.Color.Green;
            text.Visible = true;
            nextButton.Visible = true;

            nameLabel.BringToFront();
            text.BringToFront();
            nextButton.BringToFront();

            this.BackgroundImage = Properties.Resources.HomeBackground;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                clicks += 1;
                text.Text = textList[clicks];
            }

            catch (System.IndexOutOfRangeException)
            {
                text.Text = textList.Last();
            }

            if (clicks == 5)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteNeutral;
            }

            if (clicks == 7)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 9)
            {
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
                touChanSprite.Visible = true;
                touChanSprite.BringToFront();
            }

            if (clicks == 11)
            {
                touChanSprite.Image = Properties.Resources.TouChanSigh;
            }

            if (clicks == 12)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 13)
            {
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
            }

            if (clicks == 15)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 16)
            {
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
            }

            if (clicks == 18)
            {
                nameLabel.Text = "   ‍   ";
                kagami.Visible = true;
                touChanSprite.Visible = false;
                kagami.BringToFront();
            }

            if (clicks == 19)
            {
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
                kagami.Visible = false;
                this.BackgroundImage = Properties.Resources.CG1;
            }

            if (clicks == 20)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 21)
            {
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
                touChanSprite.Visible = true;
                this.BackgroundImage = Properties.Resources.HomeBackground;
            }

            if (clicks == 22)
            {
                choice1.Visible = true;
                choice2.Visible = true;
                nextButton.Visible = false;

                choice1.BringToFront();
                choice2.BringToFront();
            }

            if (clicks == 23 && correct == false)
            {
                nameLabel.Text = "   ‍   ";
                touChanSprite.Visible = false;
            }

            if (clicks == 25 && correct == false)
            {
                nameLabel.Visible = false;
                nextButton.Visible = false;
                textBox.Visible = false;
                text.Visible = false;
                yotsubaSprite.Visible = false;
                badEndRestart.Visible = true;
                this.BackgroundImage = Properties.Resources.BadEnd;
            }

            if (clicks == 25 && correct == true)
            {
                nameLabel.Visible = true;
                nameLabel.Text = "とーちゃん";
                touChanSprite.Image = Properties.Resources.TouChanMad;
            }

            if (clicks == 26)
            {
                touChanSprite.Visible = false;
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
                this.BackgroundImage = Properties.Resources.StreetBackground;
            }

            if (clicks == 29)
            {
                fuukaSprite.Visible = true;
                fuukaSprite.BringToFront();
                nameLabel.Text = "ふうか";
                nameLabel.ForeColor = System.Drawing.Color.HotPink;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 30)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
            }

            if (clicks == 31)
            {
                nameLabel.Text = "ふうか";
                nameLabel.ForeColor = System.Drawing.Color.HotPink;
                fuukaSprite.Image = Properties.Resources.FuukaConfused;
            }

            if (clicks == 32)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
                fuukaSprite.Visible = false;
                this.BackgroundImage = Properties.Resources.CG2;
            }

            if (clicks == 34)
            {
                nameLabel.Text = "ふうか";
                nameLabel.ForeColor = System.Drawing.Color.HotPink;
            }

            if (clicks == 35)
            {
                nameLabel.Text = "   ‍   ";
                fuukaSprite.Visible = true;
                fuukaSprite.Image = Properties.Resources.FuukaHurt;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
                this.BackgroundImage = Properties.Resources.StreetBackground;
            }

            if (clicks == 36)
            {
                nameLabel.Text = "ふうか";
            }

            if (clicks == 38)
            {
                fuukaSprite.Visible = false;
                nameLabel.Text = "   ‍   ";
                this.BackgroundImage = Properties.Resources.ParkBackground;
            }

            if (clicks == 39)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 40)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteNeutral;
            }

            if (clicks == 41)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteCrying;
            }

            if (clicks == 45)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSleepy;
            }

            if (clicks == 49)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 51)
            {
                nameLabel.Text = "   ‍   ";
                donburi.Visible = true;
            }

            if (clicks == 52)
            {
                nameLabel.Text = "よつば";
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteHappy;
                donburi.Visible = false;
            }

            if (clicks == 54)
            {
                nameLabel.Text = "?????";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 55)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 58)
            {
                juraluminSprite.Visible = true;
                juraluminSprite.Image = Properties.Resources.Juralumin;
                juraluminSprite.BringToFront();
                nameLabel.Text = "?????";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 59)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
            }

            if (clicks == 60)
            {
                nameLabel.Text = "?????";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminHappy;
            }

            if (clicks == 64)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
            }

            if (clicks == 65)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteNeutral;
            }

            if (clicks == 66)
            {
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 68)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 69)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
            }

            if (clicks == 71)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.Juralumin;
            }

            if (clicks == 73)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
            }

            if (clicks == 75)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminAngry;
            }

            if (clicks == 77)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 78)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 80)
            {
                nextButton.Visible = false;
                choice3.Visible = true;
                choice4.Visible = true;
                choice3.BringToFront();
                choice4.BringToFront();
            }

            if (clicks == 81)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.Juralumin;
            }

            if (clicks == 82)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 83)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 84)
            {
                nameLabel.Text = "   ‍   ";
            }

            if (clicks == 87 && correct1 == false)
            {
                nameLabel.Visible = false;
                nextButton.Visible = false;
                textBox.Visible = false;
                text.Visible = false;
                yotsubaSprite.Visible = false;
                juraluminSprite.Visible = false;
                badEndRestart.Visible = true;
                this.BackgroundImage = Properties.Resources.BadEnd;
            }

            if (clicks == 87 && correct1 == true)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 89)
            {
                nameLabel.Text = "   ‍   ";
                juraluminSprite.Visible = false;
                yandaPic.Visible = true;
                yandaPic.BringToFront();
            }

            if (clicks == 90)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteNeutral;
                yandaPic.Visible = false;
                juraluminSprite.Visible = true;
            }

            if (clicks == 91)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 92)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 93)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 94)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 95)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminEmbarrassed;
            }

            if (clicks == 99)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
                juraluminSprite.Image = Properties.Resources.JuraluminAngry;
            }

            if (clicks == 100)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 102)
            {
                this.BackgroundImage = Properties.Resources.Konbini;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
            }

            if (clicks == 105)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            }

            if (clicks == 106)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteNeutral;
            }

            if (clicks == 108)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
            }

            if (clicks == 109)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
            }

            if (clicks == 110)
            {
                nameLabel.Text = "イヤンダマン";
                nameLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
                juraluminSprite.Visible = false;
                iyandaSprite.Visible = true;
                iyandaSprite.BringToFront();
            }

            if (clicks == 112)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Visible = true;
                iyandaSprite.Visible = false;
                juraluminSprite.BringToFront();
            }

            if (clicks == 114)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
                juraluminSprite.Visible = false;
                iyandaSprite.Visible = true;
                iyandaSprite.BringToFront();
            }

            if (clicks == 116)
            {
                nameLabel.Text = "イヤンダマン";
                nameLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            }

            if (clicks == 118)
            {
                iyandaSprite.Image = Properties.Resources.IyandamanSurprised;
            }

            if (clicks == 120)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                iyandaSprite.Visible = false;
                this.BackgroundImage = Properties.Resources.CG3;
            }

            if (clicks == 122)
            {
                nameLabel.Text = "イヤンダマン";
                nameLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            }

            if (clicks == 123)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Visible = true;
                juraluminSprite.Image = Properties.Resources.JuraluminHappy;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
                this.BackgroundImage = Properties.Resources.Konbini;
            }

            if (clicks == 124)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
                portal.Visible = true;
            }

            if (clicks == 125)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.Juralumin;
            }

            if (clicks == 126)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 127)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminSad;
            }

            if (clicks == 129)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
                yotsubaSprite.Image = Properties.Resources.YotsubaSpriteCrying;
                nextButton.Visible = false;
                choice5.Visible = true;
                choice6.Visible = true;
                choice7.Visible = true;
                choice5.BringToFront();
                choice6.BringToFront();
                choice7.BringToFront();
            }

            if (clicks == 130)
            {
                clicks = 128;
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.Juralumin;
            }

            if (clicks == 131)
            {
                clicks = 128;
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminEmbarrassed;
            }

            if (clicks == 132)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.Juralumin;
            }

            if (clicks == 133)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 135)
            {
                nameLabel.Text = "ジュラルミン";
                nameLabel.ForeColor = System.Drawing.Color.MediumPurple;
                juraluminSprite.Image = Properties.Resources.JuraluminHappy;
            }

            if (clicks == 137)
            {
                juraluminSprite.Image = Properties.Resources.JuraluminSad;
            }

            if (clicks == 138)
            {
                nameLabel.Text = "よつば";
                nameLabel.ForeColor = System.Drawing.Color.Green;
            }

            if (clicks == 139)
            {
                yotsubaSprite.Visible = false;
                juraluminSprite.Visible = false;
                portal.Visible = false;
                textBox.Visible = false;
                textBox2.Visible = true;
                this.BackgroundImage = Properties.Resources.Credits;
                nameLabel.Visible = false;
            }

            if (clicks == 141)
            {
                nameLabel.Visible = true;
                nameLabel.Text = "とーちゃん";
                nameLabel.ForeColor = System.Drawing.Color.Maroon;
                touChan.Visible = true;
                touChan.Parent = textBox2;
                touChan.Location = new Point(0, 0);
            }

            if (clicks == 146)
            {
                touChan.Visible = false;
                touChanSmile.Visible = true;
                touChanSmile.Parent = textBox2;
                touChanSmile.Location = new Point(0, 0);
            }

            if (clicks == 147)
            {
                textBox2.Visible = false;
                text.Visible = false;
                nameLabel.Visible = false;
                nextButton.Visible = false;
                this.BackgroundImage = Properties.Resources.EndScreen1;
                endScreenButton.Visible = true;
            }
        }

        private void choice1_Click(object sender, EventArgs e)
        {
            clicks += 2;
            nextButton.Visible = true;
            nameLabel.Text = "   ‍   ";
            yotsubaSprite.Image = Properties.Resources.YotsubaSpriteTired;
            text.Text = "とーちゃんからにげた！";

            choice1.Visible = false;
            choice2.Visible = false;
        }

        private void choice2_Click(object sender, EventArgs e)
        {
            correct = false;
            nextButton.Visible = true;
            nameLabel.Text = "よつば";
            nameLabel.ForeColor = System.Drawing.Color.Green;
            yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSleepy;
            text.Text = "はい。。。";

            choice1.Visible = false;
            choice2.Visible = false;
        }

        private void choice3_Click(object sender, EventArgs e)
        {
            correct1 = false;
            nextButton.Visible = true;
            nameLabel.Text = "よつば";
            nameLabel.ForeColor = System.Drawing.Color.Green;
            yotsubaSprite.Image = Properties.Resources.YotsubaSpriteAngry;
            text.Text = "うそつき！！";
            choice3.Visible = false;
            choice4.Visible = false;
        }

        private void choice4_Click(object sender, EventArgs e)
        {
            clicks += 6;
            nextButton.Visible = true;
            nameLabel.Text = "よつば";
            nameLabel.ForeColor = System.Drawing.Color.Green;
            yotsubaSprite.Image = Properties.Resources.YotsubaSpriteSurprised;
            text.Text = "イヤンダマン？！";

            choice3.Visible = false;
            choice4.Visible = false;
        }

        private void choice5_Click(object sender, EventArgs e)
        {
            text.Text = "このかがみ、ジュラルミンにあげる。";
            nextButton.Visible = true;
            choice5.Visible = false;
            choice6.Visible = false;
            choice7.Visible = false;
        }

        private void choice6_Click(object sender, EventArgs e)
        {
            clicks = 131;
            text.Text = "このどんぐり、ジュラルミンにあげる。";
            nextButton.Visible = true;
            choice5.Visible = false;
            choice6.Visible = false;
            choice7.Visible = false;
        }

        private void choice7_Click(object sender, EventArgs e)
        {
            clicks = 130;
            text.Text = "このえを、ジュラルミンにかえす。";
            nextButton.Visible = true;
            choice5.Visible = false;
            choice6.Visible = false;
            choice7.Visible = false;
        }

        private void badEndRestart_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.StartScreen;
            badEndRestart.Visible = false;
            startButton.Visible = true;
            text.Text = "。。。";
        }

        private void endScreenButton_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.StartScreen;
            endScreenButton.Visible = false;
            startButton.Visible = true;
            text.Text = "。。。";
        }
    }
}
