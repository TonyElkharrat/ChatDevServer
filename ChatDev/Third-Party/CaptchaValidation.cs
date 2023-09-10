using Microsoft.AspNetCore.Mvc;

namespace ChatDev.Third_Party
{
    public static class CaptchaValidation
    {
        public static async Task<bool> IsCaptchaTokenValidAsync(string captchaToken, IConfiguration configuration)
        {
            var secretKey = configuration["RecaptchaSettings:SiteKey"];
            using var httpClient = new HttpClient();
            var response = await httpClient
                .PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={captchaToken}", null);

            if (response.IsSuccessStatusCode)
            {
                dynamic captachResponse = await response.Content.ReadAsStringAsync();
                if (captachResponse.Success)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
