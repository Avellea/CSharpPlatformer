using Godot;
using System;



public class MainMenu2 : Node {

	const string GAME_VERSION = "1.0 - DEBUG";


	public override void _Ready() {

		Config config = new Config();
		config.CheckExist();
	}


	public static void setConfig() {
		Config config = new Config();
		config.CheckExist();
	}

	public void saveSettings() {
		Config config = new Config();
		config.Save();
	}

	public void _on_start_pressed() {
		GetTree().ChangeScene("res://Scenes/PlayerTest.tscn");
	}

	public void _on_options_pressed() {
		GetTree().ChangeScene("res://Scenes/Menu/Options.tscn");
	}

	public void _on_quit_pressed() {
		GetTree().Quit();
	}

	///////////////////////////////////////////////////////////
	///OPTIONS MENU SIGNALS
	///////////////////////////////////////////////////////////

	public void _on_fullscreen_pressed() {
		OS.WindowFullscreen = !OS.WindowFullscreen;
		saveSettings();
	}

	public void _on_en_translate_pressed() {
		TranslationServer.SetLocale("en");
		saveSettings();
	}

	public void _on_jp_translate_pressed() {
		TranslationServer.SetLocale("ja_JP");
		saveSettings();
	}

	public void _on_back_pressed() {
		GetTree().ChangeScene("res://Scenes/Menu/Menu2.tscn");
	}



}
