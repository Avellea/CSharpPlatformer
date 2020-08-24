extends Control

onready var animationPlayer = $AnimationPlayer

func _ready():

	var cs_class = preload("res://Scenes/Menu/Scripts/MainMenu2.cs")

	var cs_node = cs_class.new()
	cs_node.setConfig();
	

	animationPlayer.play("Fade")
	yield(animationPlayer, "animation_finished")
	get_tree().change_scene("res://Scenes/Menu/Menu2.tscn")
