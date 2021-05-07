using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeTests
{
    class AudioSwitcherTests : TestConfiguration
    {
        [Test]
        public void AudioSwitcher_ShouldTurnOffAudio()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickAudioSwitcher();
            Assert.IsFalse(ticTacToePage.IsAudioOn());
        }

        [Test]
        public void AudioSwitcher_ShouldTurnOnAudio()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickAudioSwitcher();
            if (!ticTacToePage.IsAudioOn())
                ticTacToePage.ClickAudioSwitcher();
            Assert.IsTrue(ticTacToePage.IsAudioOn());
        }
    }
}
