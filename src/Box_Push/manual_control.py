import gymnasium as gym
import numpy as np
import keyboard
import gym_donkeycar

# keyboard library requires sudo to run. Use:
# sudo /home/gabriel/dev/TEA_Lab/sdsandbox/.venv/bin/python /home/gabriel/dev/TEA_Lab/sdsandbox/src/Box_Push/manual_control.py

# poll to receive an action vector for the car.
def read_inputs():
    throttle = dir_bool_to_int(keyboard.is_pressed("up"), keyboard.is_pressed("down"))
    # right is negative, left is positive. weird
    steer = dir_bool_to_int(keyboard.is_pressed("right"), keyboard.is_pressed("left"))
    return np.array([steer, throttle])

# takes two bools, positive and negative directions, and returns their integer sum from (-1, 1)
def dir_bool_to_int(positive_bool, negative_bool):
    sum = 0
    if positive_bool: sum += 1
    if negative_bool: sum -= 1
    return sum

def main():
    env = gym.make("donkey-box-push-v0")

    obs, info = env.reset()
    try:
        while True:
            # read keyboard inputs
            input = read_inputs()

            action = np.array([0,0])

            action = input
            # execute the action
            obs, reward, terminated, truncated, info = env.step(action)
            if "obj_pos" in info:
                print(f"Object Pose: {info['obj_pos']}")
            if "goal_pos" in info:
                print(f"Goal Pose: {info['goal_pos']}")
            print(f"Reward: {reward}")
                
    except KeyboardInterrupt:
        # You can kill the program using ctrl+c
        pass

        # Exit the scene
    env.close()

if __name__ == "__main__":
    main()